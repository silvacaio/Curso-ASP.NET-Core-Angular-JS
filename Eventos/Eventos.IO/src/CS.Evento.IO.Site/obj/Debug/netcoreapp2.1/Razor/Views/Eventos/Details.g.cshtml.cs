#pragma checksum "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8fc8dd8e9619271f244ab310143707a7bb790829"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Eventos_Details), @"mvc.1.0.view", @"/Views/Eventos/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Eventos/Details.cshtml", typeof(AspNetCore.Views_Eventos_Details))]
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
#line 1 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\_ViewImports.cshtml"
using CS.Evento.IO.Site;

#line default
#line hidden
#line 2 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\_ViewImports.cshtml"
using CS.Evento.IO.Site.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fc8dd8e9619271f244ab310143707a7bb790829", @"/Views/Eventos/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f6bfbcd21725892de9e73e34bb692be1a5f66fc", @"/Views/_ViewImports.cshtml")]
    public class Views_Eventos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CS.Eventos.IO.Application.ViewModels.EventoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(106, 129, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>EventoViewModel</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(236, 40, false);
#line 14 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(276, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(320, 36, false);
#line 17 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(356, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(400, 50, false);
#line 20 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DescricaoCurta));

#line default
#line hidden
            EndContext();
            BeginContext(450, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(494, 46, false);
#line 23 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DescricaoCurta));

#line default
#line hidden
            EndContext();
            BeginContext(540, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(584, 50, false);
#line 26 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DescricaoLonga));

#line default
#line hidden
            EndContext();
            BeginContext(634, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(678, 46, false);
#line 29 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DescricaoLonga));

#line default
#line hidden
            EndContext();
            BeginContext(724, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(768, 46, false);
#line 32 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DataInicio));

#line default
#line hidden
            EndContext();
            BeginContext(814, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(858, 42, false);
#line 35 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DataInicio));

#line default
#line hidden
            EndContext();
            BeginContext(900, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(944, 45, false);
#line 38 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateFinal));

#line default
#line hidden
            EndContext();
            BeginContext(989, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1033, 41, false);
#line 41 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateFinal));

#line default
#line hidden
            EndContext();
            BeginContext(1074, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1118, 44, false);
#line 44 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Gratuito));

#line default
#line hidden
            EndContext();
            BeginContext(1162, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1206, 40, false);
#line 47 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Gratuito));

#line default
#line hidden
            EndContext();
            BeginContext(1246, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1290, 41, false);
#line 50 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(1331, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1375, 37, false);
#line 53 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(1412, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1456, 42, false);
#line 56 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Online));

#line default
#line hidden
            EndContext();
            BeginContext(1498, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1542, 38, false);
#line 59 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Online));

#line default
#line hidden
            EndContext();
            BeginContext(1580, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1624, 47, false);
#line 62 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NomeEmpresa));

#line default
#line hidden
            EndContext();
            BeginContext(1671, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1715, 43, false);
#line 65 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.NomeEmpresa));

#line default
#line hidden
            EndContext();
            BeginContext(1758, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1802, 45, false);
#line 68 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Categoria));

#line default
#line hidden
            EndContext();
            BeginContext(1847, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1891, 44, false);
#line 71 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Categoria.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1935, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1979, 49, false);
#line 74 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OrganizadorId));

#line default
#line hidden
            EndContext();
            BeginContext(2028, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2072, 45, false);
#line 77 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
       Write(Html.DisplayFor(model => model.OrganizadorId));

#line default
#line hidden
            EndContext();
            BeginContext(2117, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2164, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27bfc7fcdc0845bfae164a252425cd6e", async() => {
                BeginContext(2210, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 82 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2218, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2226, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35d31fe4976a417fad12f931d8362133", async() => {
                BeginContext(2248, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2264, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CS.Eventos.IO.Application.ViewModels.EventoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591