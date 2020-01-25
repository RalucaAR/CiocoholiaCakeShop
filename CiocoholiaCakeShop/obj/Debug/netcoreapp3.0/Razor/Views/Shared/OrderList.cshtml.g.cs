#pragma checksum "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae1040eef0c0bbf813e18dba5714156f9cf4ddad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_OrderList), @"mvc.1.0.view", @"/Views/Shared/OrderList.cshtml")]
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
#line 1 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\_ViewImports.cshtml"
using CiocoholiaCakeShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\_ViewImports.cshtml"
using CiocoholiaCakeShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae1040eef0c0bbf813e18dba5714156f9cf4ddad", @"/Views/Shared/OrderList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"888169e4ce80dd096d1491c96d02df874f30401b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_OrderList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CakeShop.API.ViewModels.MyOrderViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
 if (Model?.Count() <= 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <p>You have not any order yet!</p>\r\n    </div>\r\n");
#nullable restore
#line 8 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
    return;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-striped text-center\">\r\n    <thead>\r\n        <tr>\r\n            <th>Billing Address</th>\r\n            <th>Order summary</th>\r\n            <th>Total</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 21 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
         foreach (var order in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n\r\n                <td class=\"text-justify\">\r\n                    <div>\r\n                        ");
#nullable restore
#line 27 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                   Write(order.OrderPlaceDetails.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n                        ");
#nullable restore
#line 28 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                   Write(order.OrderPlaceDetails.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        ");
#nullable restore
#line 31 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                   Write(order.OrderPlaceDetails.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div>");
#nullable restore
#line 33 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                    Write(order.OrderPlaceDetails.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div>");
#nullable restore
#line 34 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                    Write(order.OrderPlaceDetails.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <br />\r\n                    <div>\r\n                        ");
#nullable restore
#line 37 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                   Write(order.OrderPlacedTime.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n\r\n                </td>\r\n\r\n\r\n                <td>\r\n                    <table class=\"table\">\r\n                        <tbody>\r\n");
#nullable restore
#line 46 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                             foreach (var item in order.CakeOrderInfos)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 50 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 53 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                                   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" lei * ");
#nullable restore
#line 53 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
                                                     Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 57 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n\r\n                    </table>\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"
               Write(order.OrderTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 67 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\OrderList.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CakeShop.API.ViewModels.MyOrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
