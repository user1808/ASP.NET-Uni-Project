#pragma checksum "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b65ae1cf2143f7e9bdc13eaa94e426a29ae6694d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyCart_Order), @"mvc.1.0.view", @"/Views/MyCart/Order.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\_ViewImports.cshtml"
using CRUDProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\_ViewImports.cshtml"
using CRUDProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b65ae1cf2143f7e9bdc13eaa94e426a29ae6694d", @"/Views/MyCart/Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d9c3f1ab80b2b7207bc47cfee77413f3cb661d5", @"/Views/_ViewImports.cshtml")]
    public class Views_MyCart_Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<(CRUDProject.Models.Article, int)>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
  
    bool cartEmpty = ViewBag.cartEmpty;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Your Order</h1>\r\n\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 13 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
               Write(Html.DisplayNameFor(model => model[0].Item1.ArticleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 16 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
               Write(Html.DisplayNameFor(model => model[0].Item1.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"text-center\">\r\n                    Image\r\n                </th>\r\n                <th>\r\n                    In The Cart\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 25 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
               Write(Html.DisplayNameFor(model => model[0].Item1.ArticlePrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"text-right\" style=\"font-size: large\">\r\n                    Sum\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Item1.ArticleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Item1.Category.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1304, "\"", 1348, 1);
#nullable restore
#line 43 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
WriteAttributeValue("", 1310, Url.Content(item.Item1.ImageFilename), 1310, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Image\" style=\"width: 100px; height: 100px;\" />\r\n                    </td>\r\n                    <td class=\"text-center\" style=\"font-size: large\">\r\n                        ");
#nullable restore
#line 46 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Item2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\" style=\"font-size: large\">\r\n                        ");
#nullable restore
#line 49 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Item1.ArticlePrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <p class=\"text-right\" style=\"font-size: large\">\r\n                            <b>");
#nullable restore
#line 53 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
                           Write(item.Item1.ArticlePrice * item.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" zł</b>\r\n                        </p>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <div class=\"text-right\" style=\"font-size: xx-large\">\r\n        <strong>TOTAL PRICE: </strong>\r\n        ");
#nullable restore
#line 62 "C:\Users\Lenovo\source\repos\CRUDProject\CRUDProject\Views\MyCart\Order.cshtml"
   Write(ViewBag.cartValue);

#line default
#line hidden
#nullable disable
            WriteLiteral(" zł\r\n    </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<(CRUDProject.Models.Article, int)>> Html { get; private set; }
    }
}
#pragma warning restore 1591