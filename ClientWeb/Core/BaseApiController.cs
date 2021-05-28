using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.client;
using DAL;
using Common.Web;
using System.Net.Http;
using System.Text;


namespace ClientWeb.Core
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiController: ControllerBase
    {
        Common.Str.DESEncrypt des = new Common.Str.DESEncrypt();
        public stclientContext dbcontextWeb = null;
     


        public BaseApiController()
        {
            if(Program.sqlurlWeb.IsNullOrEmpty())
            {
                //从本地配置文件读取配置信息
                Program.LoadConfig();
            }
            dbcontextWeb = new stclientContext(Program.sqlurlWeb);
          
        }

        public string ToJson(object o)
        {
            return Common.Json.ClassJson.ClassToJson(o);
        }
        /// <summary>
        /// 返回不带引号的值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public HttpResponseMessage ToMsg(string str)
        {

            HttpResponseMessage responseMessage =
            new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "text/plain") };
            return responseMessage;
        }

        /// <summary>
        /// 成功的值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object Success(object msg)
        {
            return new { rt = true, msg = msg };
        }

        /// <summary>
        /// 失败的值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object Fail(string msg)
        {
            return new { rt = false, msg = msg };
        }


        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public string GetHostAddress()
        {
            string userHostAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public string ReqPara(string key)
        {
            string val = null;
            if (Request.HasFormContentType && Request.Form.ContainsKey(key))
            {
                val = Request.Form[key];
            }
            else if (Request.Query.ContainsKey(key))
            {
                val = Request.Query[key];
            }
            val = System.Net.WebUtility.UrlDecode(val);//获取提交过来的数据，并解码
            val = Common.Web.InjectionAttack.MyEncodeInputString(val);//对关键字符进行过滤
            return val;
        }
    }
}
