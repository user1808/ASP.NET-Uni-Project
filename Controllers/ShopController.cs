using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CRUDProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyDbContext _context;

        public ShopController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        public async Task<IActionResult> Items(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            ViewData["Articles"] = _context.Articles
               .Where(a => a.CategoryId == id)
               .ToList();

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [Authorize(Roles = "RegularUser")]
        public IActionResult AddToCart(int? id)
        {
            var article = _context.Articles.FirstOrDefault(art => art.ArticleId == id);
            var cartCookieJson = Request.Cookies["cart"];
            Dictionary<int, int> cart;
            if (cartCookieJson == null)
                cart = new Dictionary<int, int>();
            else
                cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartCookieJson);
                

            if (cart.Keys.Contains(article.ArticleId))
                cart[article.ArticleId] += 1;
            else
                cart[article.ArticleId] = 1;

            string responseCookie = JsonConvert.SerializeObject(cart);

            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7)
            };
            Response.Cookies.Append("cart", responseCookie, option);

            return RedirectToAction("Items", new { id = article.CategoryId });
        }
    }
}
