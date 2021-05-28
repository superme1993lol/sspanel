using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common.Web;
using Model;
using Model.admin;
using Model.client;

namespace ClientWeb.Core
{

    public class Project
    {
        public static string LoginKey = "ClientLoginKey";

        /// <summary>
        /// 获取默认的值
        /// </summary>
        /// <param name="o"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetDefaultVal(object o, string key)
        {
            if (!ReqPara(key).IsNullOrEmpty()) return ReqPara(key);
            else if (o != null) return o.GetType().GetProperty(key).GetValue(o, null);
            else return "";
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public static bool Submit(DbContext dbc)
        {
            try
            {
                int num = dbc.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取请求的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public static string ReqPara(string key)
        {
            string val = HttpContext.Current.Request.Query[key];
            if (val == null) return null;
            val = System.Net.WebUtility.UrlDecode(val);//获取提交过来的数据，并解码
            val = Common.Web.InjectionAttack.MyEncodeInputString(val);//对关键字符进行过滤
            return val;
        }

        /// <summary>
        /// 反射取值
        /// </summary>
        /// <param name="o"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static dynamic GetVal(dynamic o, string key)
        {
            var a = o.GetType().GetProperty(key);
            return a == null ? null : a.GetValue(o, null);
        }


    }
}
