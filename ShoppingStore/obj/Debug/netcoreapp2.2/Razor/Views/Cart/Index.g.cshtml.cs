#pragma checksum "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e81d7f0bdc7688bd694d8a6e9fc503f02e3d1c77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cart/Index.cshtml", typeof(AspNetCore.Views_Cart_Index))]
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
#line 1 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/_ViewImports.cshtml"
using ShoppingStore;

#line default
#line hidden
#line 2 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/_ViewImports.cshtml"
using ShoppingStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e81d7f0bdc7688bd694d8a6e9fc503f02e3d1c77", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4374419cf835837bc4d9ffae275f900231652f5c", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShoppingStore.Models.ShoppingCart>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/cart.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("item-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Checkout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "Get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/cart.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
  
    ViewData["Title"] = "Shopping Cart";
    var total = 0.0;

#line default
#line hidden
            BeginContext(126, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(144, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(150, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e81d7f0bdc7688bd694d8a6e9fc503f02e3d1c776608", async() => {
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
                BeginContext(211, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(216, 590, true);
            WriteLiteral(@"
<!-- cart -->
<div class=""cart-bg"">

    <!-- cart title -->
    <div class=""w hd clear"">
        <div class=""hd-left lf"">
            <h3>Shopping Cart</h3>
        </div>
    </div>

    <!-- cart wrap -->
    <div class=""cart-wrap"">
        <table class=""w clear cart-table"">
            <thead>
                <tr>
                    <th>Product</th>
                    <td>Title</td>
                    <td>Unit Price</td>
                    <td>Amount</td>
                    <td>Edit</td>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 34 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#line 36 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
                     foreach (var cart in Model)
                    {
                        total += cart.Item.Price * cart.Number;

#line default
#line hidden
            BeginContext(1000, 96, true);
            WriteLiteral("                        <tr>\r\n                            <th>\r\n                                ");
            EndContext();
            BeginContext(1096, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e81d7f0bdc7688bd694d8a6e9fc503f02e3d1c779398", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1106, "~/img/", 1106, 6, true);
#line 41 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
AddHtmlAttributeValue("", 1112, cart.Item.Image, 1112, 16, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1147, 72, true);
            WriteLiteral("\r\n                            </th>\r\n                            <td> <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1219, "\"", 1249, 2);
            WriteAttributeValue("", 1226, "/item/", 1226, 6, true);
#line 43 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
WriteAttributeValue("", 1232, cart.Item.ItemId, 1232, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1250, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1252, 14, false);
#line 43 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
                                                              Write(cart.Item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1266, 44, true);
            WriteLiteral("</a></td>\r\n                            <td>$");
            EndContext();
            BeginContext(1311, 15, false);
#line 44 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
                            Write(cart.Item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(1326, 433, true);
            WriteLiteral(@"</td>
                            <td>
                                <!-- amount -->
                                <div class=""number clear"">
                                    <div class=""selnum lf"">
                                        <span class=""remove"">
                                            <i class=""hx""></i>
                                        </span>
                                        <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1759, "\"", 1781, 1);
#line 52 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
WriteAttributeValue("", 1764, cart.Item.ItemId, 1764, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1782, 12, true);
            WriteLiteral(" type=\"text\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1794, "\"", 1814, 1);
#line 52 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
WriteAttributeValue("", 1802, cart.Number, 1802, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1815, 427, true);
            WriteLiteral(@">
                                        <span class=""add"">
                                            <i class=""hx""></i>
                                            <i class=""sx""></i>
                                        </span>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2242, "\"", 2290, 3);
            WriteAttributeValue("", 2249, "javascript:updateCart(", 2249, 22, true);
#line 61 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
WriteAttributeValue("", 2271, cart.Item.ItemId, 2271, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 2288, ");", 2288, 2, true);
            EndWriteAttribute();
            BeginContext(2291, 47, true);
            WriteLiteral(">Update</a>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2338, "\"", 2386, 3);
            WriteAttributeValue("", 2345, "javascript:deleteCart(", 2345, 22, true);
#line 62 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
WriteAttributeValue("", 2367, cart.Item.ItemId, 2367, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 2384, ");", 2384, 2, true);
            EndWriteAttribute();
            BeginContext(2387, 79, true);
            WriteLiteral(">Delete</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 65 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
                    }

#line default
#line hidden
#line 65 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
                     
                }

#line default
#line hidden
            BeginContext(2508, 150, true);
            WriteLiteral("            </tbody>\r\n            <tfoot>\r\n                <tr>\r\n                    <th colspan=\"2\">Total</th>\r\n                    <td colspan=\"3\">$");
            EndContext();
            BeginContext(2659, 5, false);
#line 71 "/Users/BumbleBee/Documents/csye/Info6250/Assignment6/ShoppingStore/Views/Cart/Index.cshtml"
                                Write(total);

#line default
#line hidden
            EndContext();
            BeginContext(2664, 112, true);
            WriteLiteral("</td>\r\n                </tr>\r\n            </tfoot>\r\n        </table>\r\n\r\n        <div class=\"w hd\">\r\n            ");
            EndContext();
            BeginContext(2776, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e81d7f0bdc7688bd694d8a6e9fc503f02e3d1c7716345", async() => {
                BeginContext(2813, 92, true);
                WriteLiteral("\r\n                <input type=\"submit\" class=\"checkoutBtn\" value=\"Checkout\" />\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2912, 46, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2975, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2981, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e81d7f0bdc7688bd694d8a6e9fc503f02e3d1c7718385", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3040, 978, true);
                WriteLiteral(@"
    <script>
        function deleteCart(id) {
            $.ajax({
                type : ""POST"",
                url : ""/item/UpdateCart"",
                data : {
                    itemId : id,
                    number : 0
                },
                success : function(result) {
                    alert(result);
                    window.location.reload();
                }
           });
        }
        function updateCart(id) {
            var i = ""#""+id;
            $.ajax({
                type : ""POST"",
                url : ""/item/UpdateCart"",
                data : {
                    itemId : id,
                    number : $(i).val()
                },
                success : function(result) {
                    if(result!=""Success""){
                        alert(result);
                    }
                    window.location.reload();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShoppingStore.Models.ShoppingCart>> Html { get; private set; }
    }
}
#pragma warning restore 1591
