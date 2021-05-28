using ClientWeb.Core;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.client;
using Common.Web;
using Service;
using System.Text;
using System.Text.RegularExpressions;

namespace ClientWeb.Controllers
{
    public class ConfigController : BaseController
    {
        MemberDAL md = new MemberDAL();
       
        VPNServerDAL vsd = new VPNServerDAL();

        #region 基础加载
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <returns></returns>
        private Memberservice GetMemberService()
        {
            md.dbcontext = dbcontextWeb;
            vsd.dbcontext = dbcontextWeb;
           
            var token = ReqPara("token");
            var ms = md.GetServiceByToken(token);
             
            return ms;
        }

        
        /// <summary>
        /// 描 述:创建加密随机数生成器 生成强随机种子
        /// </summary>
        /// <returns></returns>
        protected int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        #endregion

        #region Clash

        public IActionResult ClashConfig()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                var key = "ClashConfig_" + ms.Token;
                var info = "";
                if (Common.MyCache.MyCache.GetCache(key) != null)
                {
                    info = Common.MyCache.MyCache.GetCache(key).ToString();
                }
                else
                {
                    info = ClashConfig(ms);
                    Common.MyCache.MyCache.SetCache(key, info, DateTime.Now.AddMinutes(6));
                }
                byte[] dd = Encoding.UTF8.GetBytes(info);
                return File(dd, "text/plain", Program.SystemName + "_Clash.yaml");

            }
            return View();
        }

        private static string clashnode = "";
        private static string clashmain = "";

        private string ClashConfig(Memberservice ms)
        {
            var info = "";
          
         
            var vlst = vsd.GetAllInUse("ss");

            #region 读取模板文件
            if(clashnode.IsNullOrEmpty())
            {
                var clashnodepath = AppContext.BaseDirectory + "template/config/clash/clashnode.tpl";
                clashnode = Common.MyFile.GetFileString(clashnodepath);
            }
            if (clashmain.IsNullOrEmpty())
            {
                var clashmainpath = AppContext.BaseDirectory + "template/config/clash/clashmain.tpl";
                clashmain = Common.MyFile.GetFileString(clashmainpath);
            }
            #endregion

            var allserver = "";
            var serverinfo = "";
            var allserver_emby = "";
            foreach (var ds in vlst)
            {
                var remark = ds.ServerName;
                
                var domain = ds.Domain;
                var obfs_params = ms.Ssport + "-" + ms.Sspwd + ".download.microsoft.com";
 

                info = clashnode.Replace("{remark}", remark).Replace("{domain}", domain).Replace("{port}", ds.Port).Replace("{method}", ds.Method).Replace("{passwd}", ds.Passwd).Replace("{obfs_params}", obfs_params);
                serverinfo += info;
                allserver += "      - " + remark + @"
";
                #region 特殊处理
                if (remark.ToLower().Contains("[emby]"))
                {
                    allserver_emby += "      - " + remark + @"
";
                }
                #endregion
            }

            var str = clashmain.Replace("{serverinfo}", serverinfo).Replace("{allserver}", allserver).Replace("{allserver_emby}", allserver_emby).Replace("{SystemName}", Program.SystemName);
            return str; 
        }


        #endregion


        #region Surge
        /// <summary>
        /// Surge配置文件
        /// </summary>
        /// <returns></returns>
        public IActionResult SurgeConfig()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                var trafficnode = "";
                try
                { 
                    string trafficUsed = (SsDbService.GetServiceAllTraffic(ms.Id,dbcontextSs)*1.0/ (1024 * 1024 * 1024) ).ToString("#0.00"); 
                    var trafficTotal = ((ms.Traffic * 1.0) / (1024 * 1024 * 1024)).ToString("#0.00");
                    trafficnode = "当前流量 " + trafficUsed + " GB / " + trafficTotal + " GB";
                }
                catch
                {
                }
                var info = SurgeConfig(ms, trafficnode); 
                byte[] dd = Encoding.UTF8.GetBytes(info);
                return File(dd, "text/plain", Program.SystemName + "_Surge.conf");
            }
            return View();
        }


        static string surgemain = "";
        private string SurgeConfig(Memberservice ms,string trafficnode)
        {
        
            
            var vlst = vsd.GetAllInUse("ss");

            #region 读取模板文件
            if (surgemain.IsNullOrEmpty())
            {
                var surgemainpath = AppContext.BaseDirectory + "template/config/surge/surgemain.tpl";
                surgemain = Common.MyFile.GetFileString(surgemainpath);
            }
            #endregion

            var splitChar = "\n";
            Regex reg = new Regex(@"%[a-f0-9]{2}");

            var allserver = "";
            var allserver_main = "";
            var chinaserver = "";
            var serverinfo = "";
            var EmbyNode = "";
            var str = "";

            foreach (var ds in vlst)
            {
                var remark = ds.ServerName;
             
                var domain = ds.Domain;
               
                var obfs_params = ms.Ssport + "-" + ms.Sspwd + ".download.microsoft.com";
                var tfo = "true";
                if (ReqPara("tfo") == "0")
                {
                    tfo = "false";
                }

                var info = remark + "= ss, " + domain + ", " + ds.Port + ", encrypt-method=" + ds.Method + ", password=" + ds.Passwd + ", obfs=http, obfs-host=" + obfs_params + ", udp-relay=true, tfo=" + tfo;
                serverinfo += info + splitChar;
                if (!allserver_main.IsNullOrEmpty())
                {
                    allserver_main += "," + remark;
                }
                else
                {
                    allserver_main += remark;
                } 
                if (!allserver.IsNullOrEmpty())
                {
                    allserver += "," + remark;
                }
                else
                {
                    allserver += remark;
                }
                if (remark.ToLower().Contains("china") || remark.ToLower().Contains("中国"))
                {
                    if (!chinaserver.IsNullOrEmpty())
                    {
                        chinaserver += "," + remark;
                    }
                    else
                    {
                        chinaserver += remark;
                    }
                }

                
            }

            str = surgemain.Replace("{SystemName}", Program.SystemName).Replace("{serverinfo}", serverinfo).Replace("{allserver_main}", allserver_main).Replace("{allserver}", allserver).Replace("{chinaserver}", chinaserver).Replace("{url}", Program.Domain + "/Config/SurgeConfig?token=" + ms.Token).Replace("{EmbyNode}", EmbyNode).Replace("{MITM_passphrase}", Program.MITM_passphrase).Replace("{MITM_p12}", Program.MITM_p12);

            return str;
        }



        #endregion



        #region QuantumultX
        public IActionResult QuantumultXConfig()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                string u = SsDbService.GetServiceUpdateTraffic(ms.Id, dbcontextSs).ToString();
                string d = SsDbService.GetServiceDownloadTraffic(ms.Id, dbcontextSs).ToString();
                string t = SsDbService.GetServiceAllTraffic(ms.Id, dbcontextSs).ToString();
                Response.Headers.Add("subscription-userinfo", "upload=" + u + "; download=" + d + "; total=" + t);
                var info = QuantumultXConfig(ms);
                return Content(info, "text/plain", Encoding.UTF8);
            }
            return View();
        }

        static string qxmain = "";

        public string QuantumultXConfig(Memberservice ms)
        {
            
          
            var vlst = vsd.GetAllInUse("ss");

            #region 读取模板文件
            if (qxmain.IsNullOrEmpty())
            {
                var qxmainpath = AppContext.BaseDirectory + "template/config/quantumultx/qxmain.tpl";
                qxmain = Common.MyFile.GetFileString(qxmainpath);
            }

            #endregion

            var allserver = "";
            var allserver_emby = "";
            foreach (var ds in vlst)
            {
                var remark = ds.ServerName;
              
                var domain = ds.Domain;
                var obfs_params = ms.Ssport + "-" + ms.Sspwd + ".download.microsoft.com";
 




                if (!allserver.IsNullOrEmpty())
                {
                    allserver += ", " + remark;
                }
                else
                {
                    allserver += remark;
                }
                 
                if (!allserver_emby.IsNullOrEmpty())
                {
                    if (remark.ToLower().Contains("[emby]"))
                    {
                        allserver_emby += ", " + remark;
                    }
                }
                else
                {
                    if (remark.ToLower().Contains("[emby]"))
                    {
                        allserver_emby += remark;
                    }
                }
            }
            var rt = qxmain.Replace("{servername}", allserver).Replace("{servername_emby}", allserver_emby).Replace("{Domain}", Program.Domain).Replace("{token}", ms.Token).Replace("{SystemName}", Program.SystemName).Replace("{MITM_p12}", Program.MITM_p12).Replace("{MITM_passphrase}", Program.MITM_passphrase);
            return rt;
        }

        #endregion




        #region 节点



        /// <summary>
        /// Surge节点
        /// </summary>
        /// <returns></returns>
        public IActionResult SurgeNode()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                string u = SsDbService.GetServiceUpdateTraffic(ms.Id, dbcontextSs).ToString();
                string d = SsDbService.GetServiceDownloadTraffic(ms.Id, dbcontextSs).ToString();
                string t = SsDbService.GetServiceAllTraffic(ms.Id, dbcontextSs).ToString();
                Response.Headers.Add("subscription-userinfo", "upload=" + u + "; download=" + d + "; total=" + t);

             
                var info = NodeListConfig(ms,"");

                return Content(info, "text/html", Encoding.UTF8);
            }
            return View();
        }

        public IActionResult SSRNode()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                string u = SsDbService.GetServiceUpdateTraffic(ms.Id, dbcontextSs).ToString();
                string d = SsDbService.GetServiceDownloadTraffic(ms.Id, dbcontextSs).ToString();
                string t = SsDbService.GetServiceAllTraffic(ms.Id, dbcontextSs).ToString();
                Response.Headers.Add("subscription-userinfo", "upload=" + u + "; download=" + d + "; total=" + t);


                var info = NodeListConfig(ms, "1");

                return Content(info, "text/html", Encoding.UTF8);
            }
            return View();
        }

        public IActionResult SSNode()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                string u = SsDbService.GetServiceUpdateTraffic(ms.Id, dbcontextSs).ToString();
                string d = SsDbService.GetServiceDownloadTraffic(ms.Id, dbcontextSs).ToString();
                string t = SsDbService.GetServiceAllTraffic(ms.Id, dbcontextSs).ToString();
                Response.Headers.Add("subscription-userinfo", "upload=" + u + "; download=" + d + "; total=" + t); 
                var info = NodeListConfig(ms, "2");

                return Content(info, "text/html", Encoding.UTF8);
            }
            return View();
        } 


        private string NodeListConfig(Memberservice ms, string qxtype)
        {
           
            var vlst = vsd.GetAllInUse("");
            if(qxtype=="1")
            {
                vlst = vlst.Where(p => p.ProxyType == "ssr").ToList();
            }
            else
            {
                vlst = vlst.Where(p => p.ProxyType == "ssr").ToList();
            }
            var splitChar = "\n";
            var str = "";
          
            foreach (var ds in vlst)
            {
                var remark = ds.ServerName;
               
                var domain = ds.Domain;
                var obfs_params = ms.Ssport + "-" + ms.Sspwd + ".download.microsoft.com";
                //var obfs_params = "";
                var proto_params = ms.Ssport + ":" + ms.Sspwd;
             
               
                var info = "";
                if (qxtype == "1")
                {
                    //SSR 
                    info = "shadowsocks = " + domain + ":" + ds.Port + ", method=" + ds.Method + ", password=" + ds.Passwd + ", ssr-protocol=" + ds.Protocol + ", ssr-protocol-param=" + proto_params + ", obfs=plain, fast-open=true, udp-relay=true, tag=" + remark;

                }
                else if (qxtype == "2")
                { 
                    //ss
                    info = "shadowsocks=" + domain + ":" + ds.Port + ", method=" + ds.Method + ", password=" + ds.Passwd + ", obfs=http, obfs-host=" +  obfs_params + ", fast-open=true, udp-relay=true, tag=" + remark;
                }
                else
                {
                    info = remark + "= ss, " + domain + ", " + ds.Port + ", encrypt-method=" + ds.Method + ", password=" + ds.Passwd + ", obfs=http, obfs-host=" + obfs_params + ", tfo=true, udp-relay=true";
                }
                str += info + splitChar;
            }
            return str;


        }
        #endregion




        #region QuantumultRules
        string qrules = "";
        public IActionResult QuantumultRules()
        {
            if (qrules.IsNullOrEmpty())
            {
                var qrulespath = AppContext.BaseDirectory + "template/config/quantumult/rules.tpl";
                qrules = Common.MyFile.GetFileString(qrulespath);
            }
            var html = qrules.Replace("{SystemName}", Program.SystemName).Replace("{Domain}", Program.Domain);
            ViewBag.html = RenderPage(html);
            return View();
        }
        #endregion


        #region QuantumultServers
        public IActionResult QuantumultServers()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                string u = SsDbService.GetServiceUpdateTraffic(ms.Id, dbcontextSs).ToString();
                string d = SsDbService.GetServiceDownloadTraffic(ms.Id, dbcontextSs).ToString();
                string t = SsDbService.GetServiceAllTraffic(ms.Id, dbcontextSs).ToString();
                Response.Headers.Add("subscription-userinfo", "upload=" + u + "; download=" + d + "; total=" + t);

                var key = "ssr_" + ms.Token;
                var info = "";
                if (Common.MyCache.MyCache.GetCache(key) != null)
                {
                    info = Common.MyCache.MyCache.GetCache(key).ToString();
                }
                else
                {
                    info = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(GetSsrConfig(ms))).Replace("=", "");
                    Common.MyCache.MyCache.SetCache(key, info, DateTime.Now.AddMinutes(6));
                }
                return Content(info, "text/html", Encoding.UTF8);
            }
            return View();
        }


        #endregion

        private string GetSsrConfig(Memberservice ms)
        {
          
            var vlst = vsd.GetAllInUse("ssr");
            var splitChar = "\n";
            var str = "";
            foreach (var ds in vlst)
            {
                var remark = ds.ServerName;
               
                var domain = ds.Domain;
                // var obfs_params = ms.Ssport + "-" + ms.Sspwd + ".download.microsoft.com"; 
                var obfs_params = "";
                var proto_params = ms.Ssport + ":" + ms.Sspwd;

                

                var Url = "";
                remark = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(remark)).Replace("=", "");
                char[] padding = { '=' };

                var start = "ssr://";

                Url = start + System.Convert.ToBase64String(Encoding.UTF8.GetBytes((domain + ":" + ds.Port + ":" + ds.Protocol + ":" + ds.Method + ":" + ds.Obfs + ":" + System.Convert.ToBase64String(Encoding.UTF8.GetBytes(ds.Passwd)).Replace("=", "") + "/?obfsparam=" + System.Convert.ToBase64String(Encoding.UTF8.GetBytes(obfs_params)).Replace("=", "") + "&protoparam=" + System.Convert.ToBase64String(Encoding.UTF8.GetBytes(proto_params)).Replace("=", "") + "&remarks=" + remark.Replace(" ", "-").Replace("+", "-") + (splitChar == "\n" ? ("&group=" + System.Convert.ToBase64String(Encoding.UTF8.GetBytes(Program.SystemName)).Replace("=", "")) : "")))).TrimEnd(padding).Replace('+', '-').Replace('/', '_');


                str += Url + splitChar;
            }
            return str;

        }


        private string GetSsConfig(Memberservice ms,string ssn)
        {
           
            var vlst = vsd.GetAllInUse("ss");
            var splitChar = "\n";
            var str = "";
            Regex reg = new Regex(@"%[a-f0-9]{2}");
            foreach (var ds in vlst)
            {
                var remark = ds.ServerName;
               
                var domain = ds.Domain;
                 var obfs_params = ms.Ssport + "-" + ms.Sspwd + ".download.microsoft.com"; 
                 
                var proto_params = ms.Ssport + ":" + ms.Sspwd;
 

                var Url = "";


                if (ssn=="sip002")
                { 
                    Url = "ss://" + Base64UrlSafeS(ds.Method + ":" + ds.Passwd) + "@" + domain + ":" + ds.Port + "/?plugin={obfs}#" + remark.Replace(" ", "%20");
                }
                else
                {
                    Url = "ss://" +
                         Base64UrlSafeS(ds.Method + ":" + ds.Passwd) +
                        "@" + domain + ":" + ds.Port + "/?plugin={obfs}&remarks=" + Base64UrlSafeS(remark) + "&group=" + Base64UrlSafeS(Program.SystemName) + "#" + remark;
                }

                Url = reg.Replace(Url, m => m.Value.ToUpperInvariant());
                var obfs1 = System.Web.HttpUtility.UrlEncode("obfs-local;obfs=http;obfs-host=" + obfs_params);
                obfs1 = reg.Replace(obfs1, m => m.Value.ToUpperInvariant());

                Url = Url.Replace("{obfs}", obfs1);

                str += Url + splitChar;
            }
            return str;
        }

        /// <summary>
        /// urlsfe的base64处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Base64UrlSafeS(string s)
        {
            char[] padding = { '=' };
            string str = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(s), Base64FormattingOptions.None).TrimEnd(padding).Replace('+', '-').Replace('/', '_').Replace(" ", "-");
            return str;
        }


        /// <summary>
        /// SSR配置文件
        /// </summary>
        /// <returns></returns>
        public IActionResult SSRConfig()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                string u = SsDbService.GetServiceUpdateTraffic(ms.Id, dbcontextSs).ToString();
                string d = SsDbService.GetServiceDownloadTraffic(ms.Id, dbcontextSs).ToString();
                string t = SsDbService.GetServiceAllTraffic(ms.Id, dbcontextSs).ToString();
                Response.Headers.Add("subscription-userinfo", "upload=" + u + "; download=" + d + "; total=" + t);

                var key = "ssr_" + ms.Token;
                var info = "";
                if (Common.MyCache.MyCache.GetCache(key) != null)
                {
                    info = Common.MyCache.MyCache.GetCache(key).ToString();
                }
                else
                {
                    info = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(GetSsrConfig(ms))).Replace("=", "");
                    Common.MyCache.MyCache.SetCache(key, info, DateTime.Now.AddMinutes(6));
                }
                return Content(info, "text/html", Encoding.UTF8);
            }
            return View();
        }


        public IActionResult SSConfig()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                string u = SsDbService.GetServiceUpdateTraffic(ms.Id, dbcontextSs).ToString();
                string d = SsDbService.GetServiceDownloadTraffic(ms.Id, dbcontextSs).ToString();
                string t = SsDbService.GetServiceAllTraffic(ms.Id, dbcontextSs).ToString();
                Response.Headers.Add("subscription-userinfo", "upload=" + u + "; download=" + d + "; total=" + t);

                var key = "ssn_" + ms.Token;
                var info = "";
                if (Common.MyCache.MyCache.GetCache(key) != null)
                {
                    info = Common.MyCache.MyCache.GetCache(key).ToString();
                }
                else
                {
                    info = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(GetSsConfig(ms,"ssn"))).Replace("=", "");
                    Common.MyCache.MyCache.SetCache(key, info, DateTime.Now.AddMinutes(6));
                }
                return Content(info, "text/html", Encoding.UTF8);
            }
            return View();
        }

        public IActionResult SSConfigSIP002()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                string u = SsDbService.GetServiceUpdateTraffic(ms.Id, dbcontextSs).ToString();
                string d = SsDbService.GetServiceDownloadTraffic(ms.Id, dbcontextSs).ToString();
                string t = SsDbService.GetServiceAllTraffic(ms.Id, dbcontextSs).ToString();
                Response.Headers.Add("subscription-userinfo", "upload=" + u + "; download=" + d + "; total=" + t);

                var key = "sip002_" + ms.Token;
                var info = "";
                if (Common.MyCache.MyCache.GetCache(key) != null)
                {
                    info = Common.MyCache.MyCache.GetCache(key).ToString();
                }
                else
                {
                    info = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(GetSsConfig(ms, "sip002"))).Replace("=", "");
                    Common.MyCache.MyCache.SetCache(key, info, DateTime.Now.AddMinutes(6));
                }
                return Content(info, "text/html", Encoding.UTF8);
            }
            return View();
        }



        public IActionResult LoonConfig()
        {
            var ms = GetMemberService();
            if (ms != null)
            {
                var key = "LoonConfig_" + ms.Token;
                var info = "";
                if (Common.MyCache.MyCache.GetCache(key) != null)
                {
                    info = Common.MyCache.MyCache.GetCache(key).ToString();
                }
                else
                {
                    info = LoonConfig(ms);
                    Common.MyCache.MyCache.SetCache(key, info, DateTime.Now.AddMinutes(6));
                }
                byte[] dd = Encoding.UTF8.GetBytes(info);
                return File(dd, "text/plain", Program.SystemName + "_Loon.conf");

            }
            return View();
        }


        private string LoonConfig(Memberservice ms)
        {
            var info = "";

            #region 读取模板文件
            var loonpath = AppContext.BaseDirectory + "template/config/loon/loonconfig.tpl";
            info = Common.MyFile.GetFileString(loonpath);
            #endregion
            var ProxyUrl = Program.Domain + "/Config/SSConfigSIP002?token=" + ms.Token;

            var str = info.Replace("{MITM_passphrase}", Program.MITM_passphrase).Replace("{MITM_p12}", Program.MITM_p12).Replace("{ProxyUrl}", ProxyUrl).Replace("{SystemName}", Program.SystemName);
            return str;
        }
    }
}
