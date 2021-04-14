using CRUDProject.Data;
using CRUDProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDProject.Controllers
{
    [Authorize(Roles = "RegularUser")]
    public class MyCartController : Controller
    {
        private readonly MyDbContext _context;

        public MyCartController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tuplesModel = new List<(Article, int)>();
            var cartCookieJson = Request.Cookies["cart"];
            double cartValue = 0;
            Dictionary<int, int> cart;
            if (cartCookieJson != null)
            {
                cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartCookieJson);
                if (cart.Count != 0)
                {
                    foreach (int articleId in cart.Keys)
                    {
                        var article = await _context.Articles.Include(art => art.Category).FirstOrDefaultAsync(art => art.ArticleId == articleId);
                        var countInCart = cart[articleId];
                        tuplesModel.Add((article, countInCart));
                        cartValue += article.ArticlePrice * countInCart;
                    }
                    ViewBag.cartEmpty = false;
                    ViewBag.cartValue = cartValue;
                }
                else
                {
                    ViewBag.cartEmpty = true;
                }
            }
            else
            {
                ViewBag.cartEmpty = true;
            }

            return View(tuplesModel);
        }

        public async Task<IActionResult> AddItem(int? id)
        {
            var tuplesModel = new List<(Article, int)>();
            double cartValue = 0;
            var cartCookieJson = Request.Cookies["cart"];
            Dictionary<int, int> cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartCookieJson);
            int key = 0;
            foreach (int articleId in cart.Keys)
            {
                var article = await _context.Articles.Include(art => art.Category).FirstOrDefaultAsync(art => art.ArticleId == articleId);
                var countInCart = cart[articleId];
                if (articleId == id) { 
                    key = articleId;
                    countInCart += 1;
                }

                tuplesModel.Add((article, countInCart));
                cartValue += article.ArticlePrice * countInCart;
            }
            cart[key] += 1;
            SetCookie("cart", JsonConvert.SerializeObject(cart), 7);

            ViewBag.cartEmpty = false;
            ViewBag.cartValue = cartValue;
            

            return View("Index", tuplesModel);
        }

        public async Task<IActionResult> SubtractItem(int? id)
        {
            var tuplesModel = new List<(Article, int)>();
            double cartValue = 0;
            var cartCookieJson = Request.Cookies["cart"];
            Dictionary<int, int> cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartCookieJson);
            int key = -1;
            int removeKey = -1;
            foreach (int articleId in cart.Keys)
            {
                if (cart[articleId] == 1)
                    removeKey = articleId;
                else
                {
                    var article = await _context.Articles.Include(art => art.Category).FirstOrDefaultAsync(art => art.ArticleId == articleId);
                    var countInCart = cart[articleId];
                    if (articleId == id)
                    {
                        key = articleId;
                        countInCart -= 1;
                    }
                    tuplesModel.Add((article, countInCart));
                    cartValue += article.ArticlePrice * countInCart;
                }
            }

            if(removeKey > -1)
            {
                cart.Remove(removeKey);
            }
            if(key > -1)
            {
                cart[key] -= 1;
            }
            SetCookie("cart", JsonConvert.SerializeObject(cart), 7);
            if (cart.Count > 0)
            {
                ViewBag.cartValue = cartValue;
                ViewBag.cartEmpty = false;
            }
            else
            {
                ViewBag.cartEmpty = true;
            }

            return View("Index", tuplesModel);
        }

        public async Task<IActionResult> RemoveItem(int? id)
        {
            var tuplesModel = new List<(Article, int)>();
            double cartValue = 0;
            var cartCookieJson = Request.Cookies["cart"];
            Dictionary<int, int> cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartCookieJson);
            int removeKey = -1;
            foreach (int articleId in cart.Keys)
            {
                if (articleId == id)
                    removeKey = articleId;
                else
                {
                    var article = await _context.Articles.Include(art => art.Category).FirstOrDefaultAsync(art => art.ArticleId == articleId);
                    var countInCart = cart[articleId];
                    tuplesModel.Add((article, countInCart));
                    cartValue += article.ArticlePrice * countInCart;
                }
            }

            if (removeKey > -1)
            {
                cart.Remove(removeKey);
            }
            SetCookie("cart", JsonConvert.SerializeObject(cart), 7);
            if (cart.Count > 0)
            {
                ViewBag.cartValue = cartValue;
                ViewBag.cartEmpty = false;
            }
            else
            {
                ViewBag.cartEmpty = true;
            }

            return View("Index", tuplesModel);
        }

        public void SetCookie(string key, string value, int? numberOfDays = null)
        {
            CookieOptions option = new CookieOptions();
            if (numberOfDays.HasValue)
                option.Expires = DateTime.Now.AddDays(numberOfDays.Value);
            Response.Cookies.Append(key, value, option);
        }

        public async Task<IActionResult> Order()
        {
            var tuplesModel = new List<(Article, int)>();
            var cartCookieJson = Request.Cookies["cart"];
            double cartValue = 0;
            Dictionary<int, int> cart;
            if (cartCookieJson != null)
            {
                cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartCookieJson);
                if (cart.Count != 0)
                {
                    foreach (int articleId in cart.Keys)
                    {
                        var article = await _context.Articles.Include(art => art.Category).FirstOrDefaultAsync(art => art.ArticleId == articleId);
                        var countInCart = cart[articleId];
                        tuplesModel.Add((article, countInCart));
                        cartValue += article.ArticlePrice * countInCart;
                    }
                    ViewBag.cartEmpty = false;
                    ViewBag.cartValue = cartValue;
                }
                else
                {
                    ViewBag.cartEmpty = true;
                }
            }
            else
            {
                ViewBag.cartEmpty = true;
            }

            return View(tuplesModel);
        }
    }
}
