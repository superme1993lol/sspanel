#pragma checksum "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dc6e92b1d46f24db162ddb87cb01724690a2fd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VpnServer_ServerList), @"mvc.1.0.view", @"/Views/VpnServer/ServerList.cshtml")]
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
#line 4 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
using AdminWeb.core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
using Model.admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
using Model.client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
using Webdiyer.AspNetCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dc6e92b1d46f24db162ddb87cb01724690a2fd0", @"/Views/VpnServer/ServerList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04d7dea00641b8026593b581abb279f7bf04476b", @"/Views/_ViewImports.cshtml")]
    public class Views_VpnServer_ServerList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
  
    Layout = null;

    List<Childsystem> syslst = ViewBag.syslst;
    var sysname = ViewBag.sysname;
    List<Vpnserver> vlst = ViewBag.List;
    List<Project.VPNCountry> clst = ViewBag.clst;
    var country = ViewBag.country;
    var isuse = ViewBag.isuse;
    var ProxyType = ViewBag.ProxyType;
    int count = ViewBag.Count;
    var ServerName = ViewBag.ServerName;
    int pageindex = ViewBag.pageindex;
    int pagesize = ViewBag.pagesize;
    var alst = new PagedList<Vpnserver>(vlst, pageindex, pagesize, count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dc6e92b1d46f24db162ddb87cb01724690a2fd05516", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 954, "\"", 964, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <title>Server List</title>\r\n    ");
#nullable restore
#line 33 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dc6e92b1d46f24db162ddb87cb01724690a2fd07172", async() => {
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 43 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
Write(Html.Partial("_Top", new { active = "vpnserver" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div style=\"float:left;padding:15px;\">\r\n\r\n                <select class=\"form-control\" id=\"syslst\" name=\"syslst\" style=\"display: inline-block;width:auto;\">\r\n");
#nullable restore
#line 50 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                     foreach (var sys in syslst)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <");
                WriteLiteral("option");
                BeginWriteAttribute("value", " value=\"", 1537, "\"", 1557, 1);
#nullable restore
#line 52 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
WriteAttributeValue("", 1545, sys.Cname, 1545, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                                 ");
#nullable restore
#line 53 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                            Write(Html.Raw(sys.Cname == sysname ? "selected" : ""));

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                            ");
#nullable restore
#line 54 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                        Write(sys.Cname);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </");
                WriteLiteral("option>\r\n");
#nullable restore
#line 56 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </select>\r\n\r\n                <select class=\"form-control\" id=\"country\" name=\"country\" style=\"display: inline-block;width:auto;\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dc6e92b1d46f24db162ddb87cb01724690a2fd09757", async() => {
                    WriteLiteral("\r\n                        地区\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 63 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                     foreach (var c in clst)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <");
                WriteLiteral("option");
                BeginWriteAttribute("value", " value=\"", 2091, "\"", 2106, 1);
#nullable restore
#line 65 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
WriteAttributeValue("", 2099, c.Id, 2099, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                                 ");
#nullable restore
#line 66 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                            Write(Html.Raw(c.Id == country ? "selected" : ""));

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                            ");
#nullable restore
#line 67 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                        Write(c.CnName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </");
                WriteLiteral("option>\r\n");
#nullable restore
#line 69 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </select>\r\n\r\n                <select class=\"form-control\" id=\"ProxyType\" name=\"ProxyType\" style=\"display: inline-block;width:auto;\">\r\n                    <");
                WriteLiteral("option");
                BeginWriteAttribute("value", " value=\"", 2467, "\"", 2475, 0);
                EndWriteAttribute();
                WriteLiteral("  >\r\n                        类型\r\n                    </");
                WriteLiteral("option>\r\n                    <");
                WriteLiteral("option value=\"ss\" ");
#nullable restore
#line 76 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                                    Write(ProxyType == "ss" ? "selected" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                        SS\r\n                    </");
                WriteLiteral("option>\r\n                    <");
                WriteLiteral("option value=\"ssr\" ");
#nullable restore
#line 79 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                                     Write(ProxyType == "ssr" ? "selected" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                        SSR\r\n                    </");
                WriteLiteral("option>\r\n                </select>\r\n\r\n                <select class=\"form-control\" id=\"isuse\" name=\"isuse\" style=\"display: inline-block;width:auto;\">\r\n                    <");
                WriteLiteral("option value=\"1\" ");
#nullable restore
#line 85 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                                   Write(isuse == "1" ? "selected" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                        在用\r\n                    </");
                WriteLiteral("option>\r\n                    <");
                WriteLiteral("option value=\"0\" ");
#nullable restore
#line 88 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                                   Write(isuse == "0" ? "selected" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                        停用\r\n                    </");
                WriteLiteral("option>\r\n                </select>\r\n\r\n                <input type=\"text\" class=\"form-control\" placeholder=\"服务器名\" name=\"ServerName\" id=\"ServerName\" aria-label=\"ServerName\" aria-describedby=\"addon-wrapping\" style=\" display: inline-block; width: 200px;\"");
                BeginWriteAttribute("value", " value=\"", 3479, "\"", 3498, 1);
#nullable restore
#line 93 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
WriteAttributeValue("", 3487, ServerName, 3487, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />

                <button type=""button"" class=""btn btn-primary"" onclick=""javascript: Search()"">查询</button>
                <button type=""button"" class=""btn btn-primary"" onclick=""javascript: AddServer()"">新增</button>
            </div>
        </div>
        <div class=""row"">
            <div class=""col"">
                <table class=""table table-bordered"">
                    <thead>
                        <tr>
                            <th scope=""col"">服务器名</th>
                            <th scope=""col"">类型</th>
                            <th scope=""col"">所属国家</th>
                            <th scope=""col"">是否可用</th>
                            <th scope=""col"">端口号</th>
                            <th scope=""col"">密码</th>
                            <th scope=""col"">操作</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 114 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                         if (vlst != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                             foreach (var g in vlst)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 119 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                           Write(g.ServerName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 120 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                           Write(g.ProxyType);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 121 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                           Write(Project.GetCountryName(g.Country));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 122 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                            Write(g.IsUse==1?"是":"否");

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 123 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                           Write(g.Port);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 124 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                           Write(g.Passwd);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 4980, "\"", 5017, 3);
                WriteAttributeValue("", 4987, "javascript:OpenServer(\'", 4987, 23, true);
#nullable restore
#line 126 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
WriteAttributeValue("", 5010, g.Id, 5010, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5015, "\')", 5015, 2, true);
                EndWriteAttribute();
                WriteLiteral(" target=\"_self\">编辑</a>\r\n                                &nbsp;\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 5116, "\"", 5155, 3);
                WriteAttributeValue("", 5123, "javascript:ChangeServer(\'", 5123, 25, true);
#nullable restore
#line 128 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
WriteAttributeValue("", 5148, g.Id, 5148, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5153, "\')", 5153, 2, true);
                EndWriteAttribute();
                WriteLiteral(" target=\"_self\">");
#nullable restore
#line 128 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                                                                                      Write(g.IsUse==1?"停用":"启用");

#line default
#line hidden
#nullable disable
                WriteLiteral("</a> \r\n                                &nbsp; \r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 5277, "\"", 5313, 3);
                WriteAttributeValue("", 5284, "javascript:DelServer(\'", 5284, 22, true);
#nullable restore
#line 130 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
WriteAttributeValue("", 5306, g.Id, 5306, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5311, "\')", 5311, 2, true);
                EndWriteAttribute();
                WriteLiteral(" target=\"_self\">删除</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 133 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n                <nav");
                BeginWriteAttribute("aria-label", " aria-label=\"", 5540, "\"", 5553, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                    ");
#nullable restore
#line 140 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
               Write(Html.Pager(alst, new PagerOptions
               {
                   FirstPageText = "首页",
                   LastPageText = "上一页",
                   PrevPageText = "下一页",
                   NextPageText = "尾页",
                   TagName = "ul",
                   CssClass = "pagination",


                   CurrentPagerItemTemplate = "<li class=\"page-item active\"><a class=\"page-link\" href''>{0}</a></li>",
                   DisabledPagerItemTemplate = "<li class=\"page-item disabled\"><a class=\"page-link\" href''>{0}</a></li>",
                   PagerItemTemplate = "<li class=\"page-item \">{0}</li>",
                   PagerItemCssClass = "page-link"
               }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n                </nav>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 166 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerList.cshtml"
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
    function AddServer() {
        window.open(""/VpnServer/ServerDetail?syslst="" + $(""#syslst"").val());
    }
    function OpenServer(id) {
        window.open(""/VpnServer/ServerDetail?cid="" + id + ""&syslst="" + $(""#syslst"").val());
    }
    function Search() {
        window.location.replace(""/VpnServer/ServerList?syslst="" + $(""#syslst"").val() + ""&ServerName="" + $(""#ServerName"").val() + ""&country="" + $(""#country"").val() + ""&isuse="" + $(""#isuse"").val() + ""&ProxyType="" + $(""#ProxyType"").val());
    }

    function ChangeServer(id) {
        if (confirm(""是否确认修改？"") == true) {
            tPost(""/VpnServer/ChangeServerSubmit?"" + Math.random() + ""&cid="" + id + ""&syslst="" + $(""#syslst"").val(), null, function (rt) {
                var rr = JSON.parse(rt);
                if (rr.Msg != """") {
                    tMsg(rr.Msg);
                }
                else {
              ");
            WriteLiteral(@"      tMsg(""修改成功"", function () { window.location.reload(); });
                }
                return;
            });
        }
    }

    function DelServer(id) {
        if (confirm(""是否确认删除？"") == true) {
            tPost(""/VpnServer/DeleteServerSubmit?"" + Math.random() + ""&cid="" + id + ""&syslst="" + $(""#syslst"").val(), null, function (rt) {
                var rr = JSON.parse(rt);
                if (rr.Msg != """") {
                    tMsg(rr.Msg);
                }
                else {
                    tMsg(""删除成功"", function () { window.location.reload(); });
                }
                return;
            });
        }
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