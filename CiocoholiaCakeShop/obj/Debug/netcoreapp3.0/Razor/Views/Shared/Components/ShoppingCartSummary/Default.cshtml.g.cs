#pragma checksum "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\Components\ShoppingCartSummary\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f71dc23e7702362b64da30f3ef29aa1e5be27fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ShoppingCartSummary_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ShoppingCartSummary/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f71dc23e7702362b64da30f3ef29aa1e5be27fe", @"/Views/Shared/Components/ShoppingCartSummary/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"888169e4ce80dd096d1491c96d02df874f30401b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ShoppingCartSummary_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CakeShop.API.ViewModels.ShoppingCartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 4 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
 if (Model.ShoppingCartItemsTotal > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span class=\"badge badge-warning\">\n        ");
#nullable restore
#line 7 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
   Write(Model.ShoppingCartItemsTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </span>\n");
#nullable restore
#line 9 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CakeShop.API.ViewModels.ShoppingCartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591