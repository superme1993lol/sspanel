#pragma checksum "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b24ec9a65d225ca4d208d7ab7bd3f534100fbb74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_Detail), @"mvc.1.0.view", @"/Views/News/Detail.cshtml")]
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
#line 1 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\_ViewImports.cshtml"
using AdminWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\_ViewImports.cshtml"
using AdminWeb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
using AdminWeb.core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
using Model.admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
using Model.client;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b24ec9a65d225ca4d208d7ab7bd3f534100fbb74", @"/Views/News/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04d7dea00641b8026593b581abb279f7bf04476b", @"/Views/_ViewImports.cshtml")]
    public class Views_News_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("fm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("fm1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
  
    Layout = null;
    List<Childsystem> syslst = ViewBag.syslst;
    var sysname = ViewBag.sysname;
   
    var Title = ViewBag.Title;
    var Content = ViewBag.Content; 

    var cid = ViewBag.cid;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b24ec9a65d225ca4d208d7ab7bd3f534100fbb745802", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 595, "\"", 605, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <title>News Detail</title>\r\n    ");
#nullable restore
#line 25 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
Write(Html.Partial("_Head"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    <style>
        .panel {
            height: 300px;
            margin: 10px;
            border: 1px solid #808080;
            border-radius: 5px;
            padding: 5px;
        }
    </style>

    <!-- Custom styles for this template -->

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b24ec9a65d225ca4d208d7ab7bd3f534100fbb747620", async() => {
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 42 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
Write(Html.Partial("_Top", new { active = "news" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b24ec9a65d225ca4d208d7ab7bd3f534100fbb748182", async() => {
                    WriteLiteral(@"
            <div class=""row"">

                <div class=""input-group mb-3 "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">请选择子系统</span>
                    </div>
                    <select class=""form-control"" id=""syslst"" name=""syslst"">
");
#nullable restore
#line 53 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
                         foreach (var sys in syslst)
                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            <");
                    WriteLiteral("option");
                    BeginWriteAttribute("value", " value=\"", 1592, "\"", 1612, 1);
#nullable restore
#line 55 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
WriteAttributeValue("", 1600, sys.Cname, 1600, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral("\r\n                                     ");
#nullable restore
#line 56 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
                                Write(Html.Raw(sys.Cname == sysname ? "selected" : ""));

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                                ");
#nullable restore
#line 57 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
                            Write(sys.Cname);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </");
                    WriteLiteral("option>\r\n");
#nullable restore
#line 59 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                    </select>
                </div>
                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">标题</span>
                    </div>
                    <input type=""text"" class=""form-control"" name=""Title"" aria-label=""输入标题"" placeholder=""输入标题"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 2277, "\"", 2293, 1);
#nullable restore
#line 66 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
WriteAttributeValue("", 2285, Title, 2285, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>

 

                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">内容</span>
                    </div>
                    <textarea type=""text"" class=""form-control"" id=""Content"" name=""Content"" aria-label=""输入文本内容"" placeholder=""输入文本内容"" aria-describedby=""inputGroup-sizing-default"" >");
#nullable restore
#line 75 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
                                                                                                                                                                             Write(Content);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</textarea>\r\n                </div>\r\n                 \r\n              \r\n\r\n                <input type=\"hidden\" name=\"cid\"");
                    BeginWriteAttribute("value", " value=\"", 2886, "\"", 2898, 1);
#nullable restore
#line 80 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
WriteAttributeValue("", 2894, cid, 2894, 4, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" />

            </div>
            <div class=""row"">
                <div class=""col"" style=""padding:5px;"">
                    <button type=""button"" class=""btn btn-primary"" onclick=""SubmitInfo()"">保存</button>
                    &nbsp; &nbsp; &nbsp;
                    <button type=""button"" class=""btn btn-primary"" onclick=""javascript: window.location.href=('/Package/List?syslst=' + $('#syslst').val())"">返回</button>
                </div>
            </div>
 

        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
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
                WriteLiteral("\r\n    </div>\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 97 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\News\Detail.cshtml"
Write(Html.Partial("_Foot"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $(function () {
        $(""#syslst"").change(function () {
            window.location.replace(""/News/Detail?syslst="" + $(""#syslst"").val());
        });
 
    })

    function SubmitInfo() {
        tPost(""/News/DetailSubmit?"" + Math.random(), $(""#fm"").serialize(), function (rt) {
            debugger
            var rr = JSON.parse(rt);
            if (rr.Msg != """") {
                tMsg(rr.Msg);
            }
            else {
                tMsg(""保存成功"", function () { window.location.href = ""/News/List?syslst="" + $(""#syslst"").val() });
            }
            return;
        });
    }
</script>

</html>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
