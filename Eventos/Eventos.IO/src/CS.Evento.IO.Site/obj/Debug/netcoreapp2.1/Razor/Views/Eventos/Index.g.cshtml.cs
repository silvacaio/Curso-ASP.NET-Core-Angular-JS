#pragma checksum "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8418ba643840ad60071f646bcb79f73c21cbcb1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Eventos_Index), @"mvc.1.0.view", @"/Views/Eventos/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Eventos/Index.cshtml", typeof(AspNetCore.Views_Eventos_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8418ba643840ad60071f646bcb79f73c21cbcb1a", @"/Views/Eventos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f6bfbcd21725892de9e73e34bb692be1a5f66fc", @"/Views/_ViewImports.cshtml")]
    public class Views_Eventos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CS.Eventos.IO.Application.ViewModels.EventoViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(74, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(117, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(146, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c952d550d224c82874b90a93ebaeedd", async() => {
                BeginContext(169, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(183, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(276, 40, false);
#line 16 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(316, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(372, 50, false);
#line 19 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DescricaoCurta));

#line default
#line hidden
            EndContext();
            BeginContext(422, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(478, 50, false);
#line 22 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DescricaoLonga));

#line default
#line hidden
            EndContext();
            BeginContext(528, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(584, 46, false);
#line 25 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DataInicio));

#line default
#line hidden
            EndContext();
            BeginContext(630, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(686, 45, false);
#line 28 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateFinal));

#line default
#line hidden
            EndContext();
            BeginContext(731, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(787, 44, false);
#line 31 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Gratuito));

#line default
#line hidden
            EndContext();
            BeginContext(831, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(887, 41, false);
#line 34 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(928, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(984, 42, false);
#line 37 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Online));

#line default
#line hidden
            EndContext();
            BeginContext(1026, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1082, 47, false);
#line 40 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NomeEmpresa));

#line default
#line hidden
            EndContext();
            BeginContext(1129, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1185, 45, false);
#line 43 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Categoria));

#line default
#line hidden
            EndContext();
            BeginContext(1230, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1286, 49, false);
#line 46 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OrganizadorId));

#line default
#line hidden
            EndContext();
            BeginContext(1335, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 52 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1453, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1502, 39, false);
#line 55 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1541, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1597, 49, false);
#line 58 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DescricaoCurta));

#line default
#line hidden
            EndContext();
            BeginContext(1646, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1702, 49, false);
#line 61 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DescricaoLonga));

#line default
#line hidden
            EndContext();
            BeginContext(1751, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1807, 45, false);
#line 64 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DataInicio));

#line default
#line hidden
            EndContext();
            BeginContext(1852, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1908, 44, false);
#line 67 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateFinal));

#line default
#line hidden
            EndContext();
            BeginContext(1952, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2008, 43, false);
#line 70 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Gratuito));

#line default
#line hidden
            EndContext();
            BeginContext(2051, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2107, 40, false);
#line 73 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(2147, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2203, 41, false);
#line 76 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Online));

#line default
#line hidden
            EndContext();
            BeginContext(2244, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2300, 46, false);
#line 79 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NomeEmpresa));

#line default
#line hidden
            EndContext();
            BeginContext(2346, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2402, 47, false);
#line 82 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Categoria.Id));

#line default
#line hidden
            EndContext();
            BeginContext(2449, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2505, 48, false);
#line 85 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrganizadorId));

#line default
#line hidden
            EndContext();
            BeginContext(2553, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2608, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d28b03b71b4f486b8af910906bd55c10", async() => {
                BeginContext(2653, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 88 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
                                       WriteLiteral(item.Id);

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
            BeginContext(2661, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2681, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fa65006302840599d7d465f495576f6", async() => {
                BeginContext(2729, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 89 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
                                          WriteLiteral(item.Id);

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
            BeginContext(2740, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2760, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7dec828cb1ed40948a3c7dc89be0aeb0", async() => {
                BeginContext(2807, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 90 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
                                         WriteLiteral(item.Id);

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
            BeginContext(2817, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 93 "D:\Cursos\ASPNET_and_ANGULARJS2\Eventos\Eventos.IO\src\CS.Evento.IO.Site\Views\Eventos\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2856, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CS.Eventos.IO.Application.ViewModels.EventoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
