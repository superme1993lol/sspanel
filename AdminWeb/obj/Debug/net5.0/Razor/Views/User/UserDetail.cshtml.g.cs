#pragma checksum "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3453689675d816623f0f798d3daab3f434adeaba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserDetail), @"mvc.1.0.view", @"/Views/User/UserDetail.cshtml")]
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
#line 2 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
using AdminWeb.core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
using Model.admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
using Model.client;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3453689675d816623f0f798d3daab3f434adeaba", @"/Views/User/UserDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04d7dea00641b8026593b581abb279f7bf04476b", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral(" \r\n");
#nullable restore
#line 5 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
  
    Layout = null;
    List<Childsystem> syslst = ViewBag.syslst;
    var sysname = ViewBag.sysname; 
    List<Project.VPNCountry> clst = ViewBag.clst;

    var cid = ViewBag.cid;


    var Account= ViewBag.Account ;
    var CreateTime=ViewBag.CreateTime;
    var IsUse= ViewBag.IsUse;
    var IsRegist= ViewBag.IsRegist;
    var IsMailSend= ViewBag.IsMailSend;
    var Email= ViewBag.Email;
    var NickName= ViewBag.NickName ; 
    List<Memberservice> lstms = ViewBag.ms;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3453689675d816623f0f798d3daab3f434adeaba6156", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 757, "\"", 767, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <title>Server Detail</title>\r\n    ");
#nullable restore
#line 31 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3453689675d816623f0f798d3daab3f434adeaba7980", async() => {
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 48 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
Write(Html.Partial("_Top", new { active = "user" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n\r\n        <div class=\"row\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3453689675d816623f0f798d3daab3f434adeaba8585", async() => {
                    WriteLiteral(@"
                <div class=""input-group mb-3 "" style=""display:none;"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">请选择子系统</span>
                    </div>
                    <select class=""form-control"" id=""syslst"" name=""syslst"">
");
#nullable restore
#line 59 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                         foreach (var sys in syslst)
                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            <");
                    WriteLiteral("option");
                    BeginWriteAttribute("value", " value=\"", 1778, "\"", 1798, 1);
#nullable restore
#line 61 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 1786, sys.Cname, 1786, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral("\r\n                                     ");
#nullable restore
#line 62 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                                Write(Html.Raw(sys.Cname == sysname ? "selected" : ""));

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                                ");
#nullable restore
#line 63 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                            Write(sys.Cname);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </");
                    WriteLiteral("option>\r\n");
#nullable restore
#line 65 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                    </select>
                </div>

                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">账户名</span>
                    </div>
                    <input type=""text"" class=""form-control"" disabled=""disabled"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 2436, "\"", 2454, 1);
#nullable restore
#line 73 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 2444, Account, 2444, 10, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>
                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">邮箱</span>
                    </div>
                    <input type=""text"" class=""form-control"" disabled=""disabled"" name=""Email"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 2870, "\"", 2886, 1);
#nullable restore
#line 79 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 2878, Email, 2878, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>
                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">昵称</span>
                    </div>
                    <input type=""text"" class=""form-control"" disabled=""disabled"" name=""NickName"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 3305, "\"", 3324, 1);
#nullable restore
#line 85 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 3313, NickName, 3313, 11, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>
                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">创建时间</span>
                    </div>
                    <input type=""text"" class=""form-control"" disabled=""disabled"" name=""CreateTime"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 3747, "\"", 3768, 1);
#nullable restore
#line 91 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 3755, CreateTime, 3755, 13, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>
                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">邮件发送状态</span>
                    </div>
                    <input type=""text"" class=""form-control"" disabled=""disabled"" name=""IsMailSend"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 4193, "\"", 4214, 1);
#nullable restore
#line 97 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 4201, IsMailSend, 4201, 13, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>

                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">注册状态</span>
                    </div>
                    <input type=""text"" class=""form-control"" disabled=""disabled"" name=""IsRegist"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 4637, "\"", 4656, 1);
#nullable restore
#line 104 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 4645, IsRegist, 4645, 11, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>
                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">账户状态</span>
                    </div>
                    <input type=""text"" class=""form-control"" disabled=""disabled"" name=""IsUse"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 5074, "\"", 5090, 1);
#nullable restore
#line 110 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 5082, IsUse, 5082, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                </div>\r\n\r\n");
#nullable restore
#line 113 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                 if (lstms != null)
                {
                    var i = 1;
                    foreach (var ms in lstms)
                    {
                        i++;

#line default
#line hidden
#nullable disable
                    WriteLiteral("                        <div class=\"input-group mb-3  \">\r\n                            <div class=\"input-group-prepend\">\r\n                                <span class=\"input-group-text\" id=\"inputGroup-sizing-default\" style=\"width:250px;\">服务");
#nullable restore
#line 121 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                                                                                                                 Write(i);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</span>\r\n                            </div>\r\n                            <input type=\"text\" class=\"form-control\" disabled=\"disabled\" name=\"ms\" aria-describedby=\"inputGroup-sizing-default\"");
                    BeginWriteAttribute("value", " value=\"", 5737, "\"", 5928, 1);
#nullable restore
#line 123 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 5745, "时间："+ms.StartTime.ToString("yyyy-MM-dd")+"~"+ms.EndTime.ToString("yyyy-MM-dd")+",流量:"+ms.Traffic/(1024*1024*1024)+"G,最大在线人数:"+ms.MaxOnlineUser+",SS端口:"+ms.Ssport+",SS密码:"+ms.Sspwd, 5745, 183, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                        </div>\r\n");
#nullable restore
#line 125 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                    }


                }

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n\r\n                <input type=\"hidden\" id=\"cid\" name=\"cid\"");
                    BeginWriteAttribute("value", " value=\"", 6070, "\"", 6082, 1);
#nullable restore
#line 131 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 6078, cid, 6078, 4, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n            ");
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
                WriteLiteral("\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col\" style=\"padding:5px;\">\r\n");
#nullable restore
#line 136 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                 if (IsMailSend == "未发送")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <button type=\"button\" class=\"btn btn-primary\" onclick=\"SendEmail()\">发送注册邮件</button>\r\n");
#nullable restore
#line 139 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
               Write(Html.Raw("&nbsp; &nbsp; &nbsp;"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 139 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                                                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 141 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                 if (IsRegist == "未激活")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <button type=\"button\" class=\"btn btn-primary\" onclick=\"Active()\">手动激活</button>\r\n");
#nullable restore
#line 144 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
               Write(Html.Raw("&nbsp; &nbsp; &nbsp;"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 144 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                                                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <button type=\"button\" class=\"btn btn-primary\" onclick=\"Change()\">\r\n");
#nullable restore
#line 148 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                 if (IsUse == "在用")
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
               Write(Html.Raw("停用"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                                   
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
               Write(Html.Raw("启用"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                                   
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </button>

                &nbsp; &nbsp; &nbsp;
                <button type=""button"" class=""btn btn-primary"" onclick=""javascript: window.location.href=('/User/UserList?syslst=' + $('#syslst').val())"">返回</button>
            </div>

        </div>

    </div>


");
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
#line 168 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
Write(Html.Partial("_Foot"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        $(\"#syslst\").change(function () {\r\n            window.location.replace(\"/User/UserDetail?cid=");
#nullable restore
#line 172 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\User\UserDetail.cshtml"
                                                      Write(cid);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"syslst="" + $(""#syslst"").val());
        });
    });
    function Change() {
        var id = $(""#cid"").val();
        if (confirm(""是否确认修改？"") == true) {
            tPost(""/User/ChangeUserSubmit?"" + Math.random() + ""&cid="" + id + ""&syslst="" + $(""#syslst"").val(), null, function (rt) {
                var rr = JSON.parse(rt);
                if (rr.Msg != """") {
                    tMsg(rr.Msg);
                }
                else {
                    tMsg(""修改成功"", function () { window.location.reload(); });
                }
                return;
            });
        }
    }


    function Active() {
        var id = $(""#cid"").val();
        if (confirm(""是否确认激活？"") == true) {
            tPost(""/User/ActiveUserSubmit?"" + Math.random() + ""&cid="" + id + ""&syslst="" + $(""#syslst"").val(), null, function (rt) {
                var rr = JSON.parse(rt);
                if (rr.Msg != """") {
                    tMsg(rr.Msg);
                }
                else {
                    tM");
            WriteLiteral(@"sg(""激活成功"", function () { window.location.reload(); });
                }
                return;
            });
        }
    }

    function SendEmail() {
        var id = $(""#cid"").val();
        if (confirm(""是否确认重新发送？"") == true) {
            tPost(""/User/SendEmailUserSubmit?"" + Math.random() + ""&cid="" + id + ""&syslst="" + $(""#syslst"").val(), null, function (rt) {
                var rr = JSON.parse(rt);
                if (rr.Msg != """") {
                    tMsg(rr.Msg);
                }
                else {
                    tMsg(""发送成功"", function () { window.location.reload(); });
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