#pragma checksum "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "654c2b7148640ec83bc6d2a172735b54255fe8e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Category/Index.cshtml", typeof(AspNetCore.Views_Category_Index))]
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
#line 1 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/_ViewImports.cshtml"
using ShoppingStore;

#line default
#line hidden
#line 2 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/_ViewImports.cshtml"
using ShoppingStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"654c2b7148640ec83bc6d2a172735b54255fe8e5", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4374419cf835837bc4d9ffae275f900231652f5c", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShoppingStore.Models.Item>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/category.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
  
    ViewData["Title"] = "Category";

#line default
#line hidden
            DefineSection("Styles", async() => {
                BeginContext(107, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(113, 65, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "654c2b7148640ec83bc6d2a172735b54255fe8e54547", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(178, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(183, 573, true);
            WriteLiteral(@"
<!-- category -->
<div class=""w clear category-bg"">
    <div class=""category-wrap"">
        <aside class=""category-aside lf"">
            <ul class=""category-link"">
                <li><a href=""/category"">All</a></li>
                <hr>
                <li><a href=""/category?type=Laptop"">Laptop</a></li>
                <hr>
                <li><a href=""/category?type=Book"">Book</a></li>
                <hr>
                <li><a href=""/category?type=CD"">CD</a></li>
            </ul>
        </aside>

        <ul class=""w clear category-list lf"">
");
            EndContext();
#line 25 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(813, 55, true);
            WriteLiteral("                <li class=\"lf\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 868, "\"", 893, 2);
            WriteAttributeValue("", 875, "/item/", 875, 6, true);
#line 28 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
WriteAttributeValue("", 881, item.ItemId, 881, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(894, 27, true);
            WriteLiteral(">\r\n                        ");
            EndContext();
            BeginContext(921, 29, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "654c2b7148640ec83bc6d2a172735b54255fe8e57495", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 931, "~/img/", 931, 6, true);
#line 29 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
AddHtmlAttributeValue("", 937, item.Image, 937, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(950, 97, true);
            WriteLiteral("\r\n                    </a>\r\n                    <div class=\"text\">\r\n                        <p><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1047, "\"", 1072, 2);
            WriteAttributeValue("", 1054, "/item/", 1054, 6, true);
#line 32 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
WriteAttributeValue("", 1060, item.ItemId, 1060, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1073, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1075, 9, false);
#line 32 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
                                                   Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1084, 86, true);
            WriteLiteral("</a></p>\r\n                        <div>\r\n                            <span class=\"lf\">");
            EndContext();
            BeginContext(1171, 10, false);
#line 34 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
                                        Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(1181, 69, true);
            WriteLiteral("</span>\r\n                            <button class=\"rf\" type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1250, "\"", 1281, 3);
            WriteAttributeValue("", 1260, "addCart(", 1260, 8, true);
#line 35 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
WriteAttributeValue("", 1268, item.ItemId, 1268, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 1280, ")", 1280, 1, true);
            EndWriteAttribute();
            BeginContext(1282, 106, true);
            WriteLiteral(">Add to Cart</button>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n");
            EndContext();
#line 39 "/Users/BumbleBee/Documents/csye/Info6250/ShoppingStore/ShoppingStore/Views/Category/Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1403, 56, true);
            WriteLiteral("        </ul>\r\n        </main>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1476, 397, true);
                WriteLiteral(@"
    <script>
        function addCart(id) {
            $.ajax({
                type : ""POST"",
                url : ""/item/AddCart"",
                data : {
                    itemId : id,
                    number : 1
                },
                success : function(result) {
                    alert(result);
                }
           });
        }
    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShoppingStore.Models.Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591