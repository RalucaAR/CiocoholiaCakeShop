#pragma checksum "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\CakeView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63e0e8c78f3d6fab33a71222657bd2c6a4103a59"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CakeView), @"mvc.1.0.view", @"/Views/Shared/CakeView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63e0e8c78f3d6fab33a71222657bd2c6a4103a59", @"/Views/Shared/CakeView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"888169e4ce80dd096d1491c96d02df874f30401b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_CakeView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CakeShop.Models.Cake>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"zoom col-lg-4 col-md-4 col-sm-5 imagcontainer\">\r\n    <div id=\"boxshadow\" class=\"card\"");
            BeginWriteAttribute("style", " style=\"", 132, "\"", 140, 0);
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 141, "\"", 221, 6);
            WriteAttributeValue("", 151, "javascript:", 151, 11, true);
            WriteAttributeValue(" ", 162, "window.location.href", 163, 21, true);
            WriteAttributeValue(" ", 183, "=", 184, 2, true);
            WriteAttributeValue(" ", 185, "\'/Product/ProductDetail/", 186, 25, true);
#nullable restore
#line 6 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\CakeView.cshtml"
WriteAttributeValue("", 210, Model.Id, 210, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 219, "\';", 219, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 258, "\"", 279, 1);
#nullable restore
#line 7 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\CakeView.cshtml"
WriteAttributeValue("", 264, Model.ImageUrl, 264, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 280, "\"", 297, 1);
#nullable restore
#line 7 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\CakeView.cshtml"
WriteAttributeValue("", 286, Model.Name, 286, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title d-inline float-left\">\r\n                ");
#nullable restore
#line 10 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\CakeView.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h5>\r\n            <br />\r\n            <p class=\"card-text d-inline float-right\">");
#nullable restore
#line 13 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\CakeView.cshtml"
                                                 Write(Model.Price.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" lei</p>\r\n            <p class=\"card-text d-inline float-right\">");
#nullable restore
#line 14 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\CakeView.cshtml"
                                                 Write(Model.Weigth);

#line default
#line hidden
#nullable disable
            WriteLiteral(" gr.</p>\r\n            <br />\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63e0e8c78f3d6fab33a71222657bd2c6a4103a597355", async() => {
                WriteLiteral("\r\n\r\n                <button class=\"btn btn-primary buy-now-btn float-right\">Buy now</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "F:\FACULTATE\AN IV\Dezvoltarea aplicatiilor WEB\Proiect\CiocoholiaCakeShop\CiocoholiaCakeShop\Views\Shared\CakeView.cshtml"
                    WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CakeShop.Models.Cake> Html { get; private set; }
    }
}
#pragma warning restore 1591
