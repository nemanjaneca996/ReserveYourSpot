#pragma checksum "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23e47f0b4b5d668ec354544127661097e91a005d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LocaleTable_Index), @"mvc.1.0.view", @"/Views/LocaleTable/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/LocaleTable/Index.cshtml", typeof(AspNetCore.Views_LocaleTable_Index))]
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
#line 1 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\_ViewImports.cshtml"
using WebMVC;

#line default
#line hidden
#line 2 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\_ViewImports.cshtml"
using WebMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23e47f0b4b5d668ec354544127661097e91a005d", @"/Views/LocaleTable/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d07e873f05b36c9d83cd6a184d4bfbe1720fee4b", @"/Views/_ViewImports.cshtml")]
    public class Views_LocaleTable_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.Responses.PagedResponse<Application.DTO.ShowLocaleTableDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(80, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(123, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(152, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23e47f0b4b5d668ec354544127661097e91a005d3823", async() => {
                BeginContext(175, 10, true);
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
            BeginContext(189, 379, true);
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Name
            </th>
            <th>
                Locale
            </th>
            <th>
                Number Of Seats
            </th>
            <th>
                Is Reserved
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 31 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
 foreach (var item in Model.Data) {

#line default
#line hidden
            BeginContext(605, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(654, 39, false);
#line 34 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(693, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(749, 45, false);
#line 37 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LocaleName));

#line default
#line hidden
            EndContext();
            BeginContext(794, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(850, 48, false);
#line 40 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumberOfSeats));

#line default
#line hidden
            EndContext();
            BeginContext(898, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(954, 45, false);
#line 43 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsReserved));

#line default
#line hidden
            EndContext();
            BeginContext(999, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1055, 53, false);
#line 46 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1108, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1129, 59, false);
#line 47 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1188, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1209, 57, false);
#line 48 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1266, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 51 "C:\Users\Nemanja\Desktop\Projekat\WebMVC\Views\LocaleTable\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1305, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.Responses.PagedResponse<Application.DTO.ShowLocaleTableDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
