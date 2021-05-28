#pragma checksum "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b09d603e6868ebe30aee72d07c813503ecba5164"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkOrder_List), @"mvc.1.0.view", @"/Views/WorkOrder/List.cshtml")]
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
#line 4 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
using AdminWeb.core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
using Model.admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
using Model.client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
using Webdiyer.AspNetCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b09d603e6868ebe30aee72d07c813503ecba5164", @"/Views/WorkOrder/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04d7dea00641b8026593b581abb279f7bf04476b", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkOrder_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 9 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
  
    Layout = null;

    List<Childsystem> syslst = ViewBag.syslst;
    var sysname = ViewBag.sysname;
    dynamic glst = ViewBag.lst;

    var Content = ViewBag.Content;

    var State = ViewBag.State;
    int count = ViewBag.Count;
    
    int pageindex = ViewBag.pageindex;
    int pagesize = ViewBag.pagesize;
    var alst = new PagedList<dynamic>(glst, pageindex, pagesize, count);


#line default
#line hidden
#nullable disable
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b09d603e6868ebe30aee72d07c813503ecba51644932", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 821, "\"", 831, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <title>Work Order List</title>\r\n    ");
#nullable restore
#line 34 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
Write(Html.Partial("_Head"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    <style>\r\n    </style>\r\n\r\n    <!-- Custom styles for this template -->\r\n\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b09d603e6868ebe30aee72d07c813503ecba51646586", async() => {
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 44 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
Write(Html.Partial("_Top", new { active = "workorder" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div style=\"float:left;padding:15px;\">\r\n                <select class=\"form-control\" id=\"syslst\" name=\"syslst\" style=\"display: inline-block;width:auto;\">\r\n");
#nullable restore
#line 50 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                     foreach (var sys in syslst)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <");
                WriteLiteral("option");
                BeginWriteAttribute("value", " value=\"", 1406, "\"", 1426, 1);
#nullable restore
#line 52 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
WriteAttributeValue("", 1414, sys.Cname, 1414, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                                 ");
#nullable restore
#line 53 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                            Write(Html.Raw(sys.Cname == sysname ? "selected" : ""));

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                            ");
#nullable restore
#line 54 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                        Write(sys.Cname);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </");
                WriteLiteral("option>\r\n");
#nullable restore
#line 56 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </select>\r\n                <select class=\"form-control\" id=\"State\" name=\"State\" style=\"display: inline-block;width:auto;\">\r\n                    <");
                WriteLiteral("option value=\"1\" ");
#nullable restore
#line 59 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                                   Write(State == "1" ? "selected" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                        正在处理\r\n                    </");
                WriteLiteral("option>\r\n                    <");
                WriteLiteral("option value=\"9\" ");
#nullable restore
#line 62 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                                   Write(State == "9" ? "selected" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                        已关闭\r\n                    </");
                WriteLiteral("option> \r\n                </select>\r\n\r\n\r\n\r\n                <input type=\"text\" class=\"form-control\" placeholder=\"请输工单内容\" name=\"Content\" id=\"Content\" aria-label=\"Content\" aria-describedby=\"addon-wrapping\" style=\" display: inline-block; width: 200px;\"");
                BeginWriteAttribute("value", " value=\"", 2267, "\"", 2283, 1);
#nullable restore
#line 69 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
WriteAttributeValue("", 2275, Content, 2275, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />

                <button type=""button"" class=""btn btn-primary"" onclick=""javascript: Search()"">查询</button> 
            </div>
        </div>
        <div class=""row"">
            <div class=""col"">
                <table class=""table table-bordered"">
                    <thead>
                        <tr>
                            <th scope=""col"">编号</th>
                            <th scope=""col"">问题内容</th>
                            <th scope=""col"">反馈人</th>
                            <th scope=""col"">创建时间</th>
                            <th scope=""col"">状态</th>
                            <th scope=""col"">操作</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 88 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                         if (glst != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                             foreach (var g in glst)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 93 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                           Write(Project.GetDefaultVal(g, "Id"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td");
                BeginWriteAttribute("title", " title=\"", 3305, "\"", 3349, 1);
#nullable restore
#line 94 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
WriteAttributeValue("", 3313, Project.GetDefaultVal(g, "Content"), 3313, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 94 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                                                                         Write(Project.GetDefaultVal(g, "Content").Length>30?(Project.GetDefaultVal(g, "Content").Substring(0,30)+"..."): Project.GetDefaultVal(g, "Content"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 95 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                           Write(Project.GetDefaultVal(g, "Email"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 96 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                           Write(Project.GetDefaultVal(g, "CreateTime").ToString("yyyy-MM-dd HH:mm:ss"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 97 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                            Write(Project.GetDefaultVal(g, "State").ToString() == "1"?"正在处理":"已关闭");

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 3860, "\"", 3917, 3);
                WriteAttributeValue("", 3867, "javascript:Open(\'", 3867, 17, true);
#nullable restore
#line 99 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
WriteAttributeValue("", 3884, Project.GetDefaultVal(g, "Id"), 3884, 31, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3915, "\')", 3915, 2, true);
                EndWriteAttribute();
                WriteLiteral(" target=\"_self\">编辑</a> \r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 102 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 113 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\WorkOrder\List.cshtml"
Write(Html.Partial("_Foot"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $(function () {
        $(""#syslst"").change(function () {
            Search();
        });
    });
    function Search() {
        window.location.replace(""/WorkOrder/List?syslst="" + $(""#syslst"").val() + ""&Content="" + $(""#Content"").val() + ""&State="" + $(""#State"").val());
    }
    
    function Open(id) {
        window.open(""/WorkOrder/Detail?cid="" + id + ""&syslst="" + $(""#syslst"").val());
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
