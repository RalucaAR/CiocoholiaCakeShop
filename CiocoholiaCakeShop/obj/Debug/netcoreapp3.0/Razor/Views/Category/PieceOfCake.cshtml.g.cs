#pragma checksum "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Category\PieceOfCake.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9eaa9e336b0307d073ac1707c693c1c24f8d484f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_PieceOfCake), @"mvc.1.0.view", @"/Views/Category/PieceOfCake.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eaa9e336b0307d073ac1707c693c1c24f8d484f", @"/Views/Category/PieceOfCake.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"888169e4ce80dd096d1491c96d02df874f30401b", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_PieceOfCake : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CakeShop.Models.Cake>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Piece of Cakes</h1>\r\n");
#nullable restore
#line 4 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Category\PieceOfCake.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n");
#nullable restore
#line 7 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Category\PieceOfCake.cshtml"
         foreach (var cake in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Category\PieceOfCake.cshtml"
       Write(await Html.PartialAsync("CakeView", cake));

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Category\PieceOfCake.cshtml"
                                                      ;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 12 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Category\PieceOfCake.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>We are sorry, we couldn\'t find any cake! &#128546; </p>\r\n");
#nullable restore
#line 16 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Category\PieceOfCake.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CakeShop.Models.Cake>> Html { get; private set; }
    }
}
#pragma warning restore 1591
