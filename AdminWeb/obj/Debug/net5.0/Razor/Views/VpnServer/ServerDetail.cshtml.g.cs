#pragma checksum "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bc4e6a1c535fcadb27fb4ee867e5316906348b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VpnServer_ServerDetail), @"mvc.1.0.view", @"/Views/VpnServer/ServerDetail.cshtml")]
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
#line 4 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
using AdminWeb.core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
using Model.admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
using Model.client;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc4e6a1c535fcadb27fb4ee867e5316906348b0", @"/Views/VpnServer/ServerDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04d7dea00641b8026593b581abb279f7bf04476b", @"/Views/_ViewImports.cshtml")]
    public class Views_VpnServer_ServerDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 7 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
  
    Layout = null;
    List<Childsystem> syslst = ViewBag.syslst;
    var sysname = ViewBag.sysname;
     List<Project.VPNCountry> clst = ViewBag.clst;

    var cid = ViewBag.cid;

    var ServerName = ViewBag.ServerName;
    var Country = ViewBag.Country;
    var IsUse = ViewBag.IsUse;
  
    var Port = ViewBag.Port;
    var Passwd = ViewBag.Passwd;
    var Method = ViewBag.Method;
    var Obfs = ViewBag.Obfs;
    var Protocol = ViewBag.Protocol;
    var ProxyType = ViewBag.ProxyType;
    var Domain = ViewBag.Domain;
    var Weight = ViewBag.Weight;


#line default
#line hidden
#nullable disable
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bc4e6a1c535fcadb27fb4ee867e5316906348b06271", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 965, "\"", 975, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <title>Server Detail</title>\r\n    ");
#nullable restore
#line 37 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bc4e6a1c535fcadb27fb4ee867e5316906348b08102", async() => {
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 54 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
Write(Html.Partial("_Top", new { active = "vpnserver" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n\r\n        <div class=\"row\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bc4e6a1c535fcadb27fb4ee867e5316906348b08719", async() => {
                    WriteLiteral(@"
                <div class=""input-group mb-3 "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">请选择子系统</span>
                    </div>
                    <select class=""form-control"" id=""syslst"" name=""syslst"">
");
#nullable restore
#line 65 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                         foreach (var sys in syslst)
                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            <");
                    WriteLiteral("option");
                    BeginWriteAttribute("value", " value=\"", 1969, "\"", 1989, 1);
#nullable restore
#line 67 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
WriteAttributeValue("", 1977, sys.Cname, 1977, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral("\r\n                                     ");
#nullable restore
#line 68 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                Write(Html.Raw(sys.Cname == sysname ? "selected" : ""));

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                                ");
#nullable restore
#line 69 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                            Write(sys.Cname);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </");
                    WriteLiteral("option>\r\n");
#nullable restore
#line 71 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                    </select>
                </div>
                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">服务器名</span>
                    </div>
                    <input type=""text"" class=""form-control"" name=""ServerName"" aria-label=""输入服务器名"" placeholder=""输入服务器名"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 2665, "\"", 2686, 1);
#nullable restore
#line 78 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
WriteAttributeValue("", 2673, ServerName, 2673, 13, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>

                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">端口号</span>
                    </div>
                    <input type=""text"" class=""form-control"" name=""Port"" aria-label=""输入端口号"" placeholder=""输入端口号"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 3123, "\"", 3138, 1);
#nullable restore
#line 85 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
WriteAttributeValue("", 3131, Port, 3131, 7, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>

                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">权重</span>
                    </div>
                    <input type=""text"" class=""form-control"" name=""Weight"" aria-label=""输入数字，数字越小排名越靠前"" placeholder=""输入数字，数字越小排名越靠前"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 3594, "\"", 3611, 1);
#nullable restore
#line 92 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
WriteAttributeValue("", 3602, Weight, 3602, 9, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>

                <div class=""input-group mb-3  "" style=""display:none;"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">域名地址</span>
                    </div>
                    <input type=""text"" class=""form-control"" name=""Domain"" aria-label=""输入域名地址"" placeholder=""输入域名地址"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 4075, "\"", 4092, 1);
#nullable restore
#line 99 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
WriteAttributeValue("", 4083, Domain, 4083, 9, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>
                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">服务器密码</span>
                    </div>
                    <input type=""text"" class=""form-control"" name=""Passwd"" aria-label=""输入服务器密码"" placeholder=""输入服务器密码"" aria-describedby=""inputGroup-sizing-default""");
                    BeginWriteAttribute("value", " value=\"", 4535, "\"", 4552, 1);
#nullable restore
#line 105 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
WriteAttributeValue("", 4543, Passwd, 4543, 9, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                </div>

                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">节点类型</span>
                    </div>
                    <select class=""form-control"" id=""ProxyType"" name=""ProxyType"">
                        <");
                    WriteLiteral("option value=\"ss\" ");
#nullable restore
#line 113 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                        Write(ProxyType == "ss" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            SS\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"ssr\" ");
#nullable restore
#line 116 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                         Write(ProxyType == "ssr" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            SSR\r\n                        </");
                    WriteLiteral(@"option>
                    </select>
                </div>


                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">Method</span>
                    </div>
                    <select class=""form-control"" id=""Method"" name=""Method"">
                        <");
                    WriteLiteral("option value=\"aes-256-cfb\" ");
#nullable restore
#line 128 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                 Write(Method == "aes-256-cfb" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            aes-256-cfb\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"aes-128-cfb\" ");
#nullable restore
#line 131 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                 Write(Method == "aes-128-cfb" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            aes-128-cfb\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"chacha20\" ");
#nullable restore
#line 134 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                              Write(Method == "chacha20" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            chacha20\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"chacha20-ietf\" ");
#nullable restore
#line 137 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                   Write(Method == "chacha20-ietf" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            chacha20-ietf\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"aes-256-gcm\" ");
#nullable restore
#line 140 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                 Write(Method == "aes-256-gcm" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            aes-256-gcm\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"aes-128-gcm\" ");
#nullable restore
#line 143 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                 Write(Method == "aes-128-gcm" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            aes-128-gcm\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"chacha20-poly1305\" ");
#nullable restore
#line 146 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                       Write(Method == "chacha20-poly1305" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            chacha20-poly1305\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"chacha20-ietf-poly1305\" ");
#nullable restore
#line 149 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                            Write(Method == "chacha20-ietf-poly1305" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            chacha20-ietf-poly1305\r\n                        </");
                    WriteLiteral(@"option>
                    </select>
                </div>

                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">Obfs</span>
                    </div>
                    <select class=""form-control"" id=""Obfs"" name=""Obfs"">
                        <");
                    WriteLiteral("option value=\"plain\" ");
#nullable restore
#line 160 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                           Write(Obfs == "plain" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            plain\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"http\" ");
#nullable restore
#line 163 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                          Write(Obfs == "http" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            http\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"tls\" ");
#nullable restore
#line 166 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                         Write(Obfs == "tls" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            tls\r\n                        </");
                    WriteLiteral(@"option>
                    </select>
                </div>



                <div class=""input-group mb-3  "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">Protocol</span>
                    </div>
                    <select class=""form-control"" id=""Protocol"" name=""Protocol"">
                        <");
                    WriteLiteral("option value=\"origin\" ");
#nullable restore
#line 179 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                            Write(Protocol == "origin" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            origin\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"auth_aes128_sha1\" ");
#nullable restore
#line 182 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                      Write(Protocol == "auth_aes128_sha1" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            auth_aes128_sha1\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"auth_aes128_md5\" ");
#nullable restore
#line 185 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                                     Write(Protocol == "auth_aes128_md5" ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            auth_aes128_md5\r\n                        </");
                    WriteLiteral(@"option>
                    </select>
                </div>


               
                <div class=""input-group mb-3 "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">请选择地区</span>
                    </div>
                    <select class=""form-control"" id=""country"" name=""country"">
");
#nullable restore
#line 198 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                         foreach (var g in clst)
                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            <");
                    WriteLiteral("option");
                    BeginWriteAttribute("value", " value=\"", 9396, "\"", 9411, 1);
#nullable restore
#line 200 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
WriteAttributeValue("", 9404, g.Id, 9404, 7, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral("\r\n                                     ");
#nullable restore
#line 201 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                Write(Html.Raw(g.Id == Country ? "selected" : ""));

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                                ");
#nullable restore
#line 202 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                            Write(g.CnName);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </");
                    WriteLiteral("option>\r\n");
#nullable restore
#line 204 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                    </select>
                </div>
                <div class=""input-group mb-3 "">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"" id=""inputGroup-sizing-default"" style=""width:250px;"">是否可用</span>
                    </div>
                    <select class=""form-control"" id=""IsUse"" name=""IsUse"">
                        <");
                    WriteLiteral("option value=\"1\" ");
#nullable restore
#line 212 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                       Write(IsUse == (short)1 ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            在用\r\n                        </");
                    WriteLiteral("option>\r\n                        <");
                    WriteLiteral("option value=\"0\" ");
#nullable restore
#line 215 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
                                       Write(IsUse == (short)0 ? "selected" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(">\r\n                            停用\r\n                        </");
                    WriteLiteral("option>\r\n                    </select>\r\n                </div>\r\n\r\n\r\n                <input type=\"hidden\" name=\"cid\"");
                    BeginWriteAttribute("value", " value=\"", 10402, "\"", 10414, 1);
#nullable restore
#line 222 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
WriteAttributeValue("", 10410, cid, 10410, 4, false);

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
                WriteLiteral(@"
        </div>
        <div class=""row"">
            <div class=""col"" style=""padding:5px;"">
                <button type=""button"" class=""btn btn-primary"" onclick=""SubmitInfo()"">保存</button>
                &nbsp; &nbsp; &nbsp;
                <button type=""button"" class=""btn btn-primary"" onclick=""javascript: window.location.href=('/VpnServer/ServerList?syslst=' + $('#syslst').val())"">返回</button>
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
#line 238 "F:\code\ssp\codeforgithub\code\SsNewPanel\AdminWeb\Views\VpnServer\ServerDetail.cshtml"
Write(Html.Partial("_Foot"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $(function () {
        $(""#syslst"").change(function () {
            window.location.replace(""/VpnServer/ServerDetail?syslst="" + $(""#syslst"").val());
        });
    });
    function SubmitInfo() {
        tPost(""/VpnServer/ServerDetailSubmit?"" + Math.random(), $(""#fm"").serialize(), function (rt) {
            debugger
            var rr = JSON.parse(rt);
            if (rr.Msg != """") {
                tMsg(rr.Msg);
            }
            else {
                tMsg(""保存成功"", function () { window.location.href = ""/VpnServer/ServerList?syslst="" + $(""#syslst"").val() });
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
