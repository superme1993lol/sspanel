using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Web;

namespace Common.Web
{
    /// <summary>
    /// 用来保存网站账户信息(采用cookie与cache联动)  
    /// </summary>
    public class Passport
    {

        /// <summary>
        /// 凭证过期时间
        /// </summary>
        public static TimeSpan PTimeSpan = new TimeSpan(0, 1, 0, 0);

        /// <summary>
        /// cookie中保存的key
        /// </summary>
        static string _passportId = "PassportId";

        #region 加在身份认证之前的字段
        private static string _defaultName = "MyObserv|Passport|PassportId=@{PassportId}|*";

        /// <summary>
        /// 加在身份认证之前的字段
        /// </summary>
        public static string DefaultName
        {
            get { return _defaultName; }
            set { _defaultName = value; }
        }
        #endregion

        public static string DoMain = ""; //主域


        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="id">passportid</param>
        /// <param name="val">对象值</param>
        public static void SetPassport(string id, object val)
        {
            SetPassport(id, val, HttpContext.Current);
        }




        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="id">passportid</param>
        /// <param name="val">对象值</param>
        public static void SetPassport(string id, object val, Microsoft.AspNetCore.Http.HttpContext context)
        {
           
            #region 获取/生成用户的passportId

            var pid_cookies = context.Request.Cookies[_passportId];
            string passportId = Guid.NewGuid().ToString();
            if (!pid_cookies.IsNullOrEmpty())
            {
                passportId = pid_cookies;
            }
            #endregion

            #region 数据存入cache
            string cacheid = DefaultName.Replace("@{PassportId}", passportId.ToLower());//存入cache中的id
            if (val == null)
            {
                MyCache.MyCache.SetCache(cacheid, null);
                return;
            }

            Hashtable hdata = null; //原始数据
            #region 首先获取过期的数据对象
            try
            {
                hdata = MyCache.MyCache.GetCache(cacheid) as Hashtable;
            }
            catch
            {
            }
            #endregion
            if (hdata == null) hdata = new Hashtable(); //如果原始数据为null，则新建
            if (hdata.Contains(id)) hdata[id] = val;
            else hdata.Add(id, val);//设置值
            MyCache.MyCache.SetCache(cacheid, null); //删除之前的数据
            MyCache.MyCache.SetCache(cacheid, hdata, DateTime.Now + PTimeSpan); //数据存入cache中 
            #endregion

            #region 设置Cookie里的passportid
            try
            {
                context.Response.Cookies.Append(_passportId, passportId.ToLower(), new Microsoft.AspNetCore.Http.CookieOptions()
                {


                });

                //cookies.Expires = DateTime.Now.AddDays(1);

            }
            catch (Exception ex)
            {

            }
            #endregion
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="id"></param>s
        public static object GetPassport(string id)
        {

            return GetPassport(id, HttpContext.Current);
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="id"></param>s
        public static object GetPassport(string id, Microsoft.AspNetCore.Http.HttpContext context)
        {
           

            if (string.IsNullOrEmpty(id)) return null;
            string passportId = null;
            //id = id.ToLower();

            #region 获取passportid
            var pid_cookies = context.Request.Cookies[_passportId];
            if (!pid_cookies.IsNullOrEmpty())
            {
                //从cookie中获取passportid
                passportId = pid_cookies;
            }
            if (string.IsNullOrEmpty(passportId))
            {
                //从request中获取passportid
                passportId = context.Request.Query[_passportId];
            }
            if (string.IsNullOrEmpty(passportId)) return null;//如果获取不到passportId，则返回
            #endregion

            #region 获取cache中的hashtable
            string cacheid = DefaultName.Replace("@{PassportId}", passportId.ToLower());//存入cache中的id
            Hashtable hdata = null;
            try { hdata = MyCache.MyCache.GetCache(cacheid) as Hashtable; }
            catch { }

            #endregion

            if (hdata != null && hdata[id] != null)
            {

                #region 再次设置cache中数据
                MyCache.MyCache.SetCache(cacheid, null); //删除之前的数据
                MyCache.MyCache.SetCache(cacheid, hdata, DateTime.Now + PTimeSpan); //数据存入cache中  
                #endregion

                return hdata[id];
            }
            else return null;
        }

        /// <summary>
        /// 删除cookie
        /// </summary>
        private static void DeleteCookie(string id)
        {
            id = id.ToLower();
            var cookies = HttpContext.Current.Request.Cookies[id];
            if (!cookies.IsNullOrEmpty())
            {

                HttpContext.Current.Response.Cookies.Delete(id, new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddDays(-1), MaxAge = new TimeSpan(-1) });
            }
        }

        /// <summary>
        /// 清除所有passport
        /// </summary>
        public static void ClearPassport(List<string> noClearKeys = null)
        {
            #region 删除缓存中的数据
            try
            {
                string passportId = null;
                var pid_cookies = HttpContext.Current.Request.Cookies[_passportId];
                if (!pid_cookies.IsNullOrEmpty())
                {
                    //从cookie中获取passportid
                    passportId = pid_cookies;
                }
                if (string.IsNullOrEmpty(passportId))
                {
                    //从request中获取passportid
                    passportId = HttpContext.Current.Request.Query[_passportId];
                }
                if (!string.IsNullOrEmpty(passportId))
                {
                    string cacheid = DefaultName.Replace("@{PassportId}", passportId.ToLower()); //存入cache中的id
                    MyCache.MyCache.SetCache(cacheid, null); //删除之前的数据
                }
            }
            catch { }
            #endregion

            #region 删除有所cookie
            try
            {
                var cookies = HttpContext.Current.Request.Cookies.Keys;
                foreach (var c in cookies)
                {
                    if (noClearKeys != null && noClearKeys.Contains(c)) continue;
                    DeleteCookie(c);
                }
            }
            catch
            {
            }
            #endregion
        }


       

    }
}
