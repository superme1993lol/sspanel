using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Common.Web
{
    public static class HttpContext
    {
        public static IServiceProvider ServiceProvider;

        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                 
                object factory = ServiceProvider.GetService(typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));
                Microsoft.AspNetCore.Http.HttpContext context = ((Microsoft.AspNetCore.Http.HttpContextAccessor)factory).HttpContext; 
                return context;
            }
        }


        /// <summary>
        /// 获取mencached里面的Session（暂时还是用Session  以后再改）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetSession(string key)
        {
            byte[] outval = null;
            if (HttpContext.Current.Session.TryGetValue(key, out outval))
            {
                return BytesToObject(outval);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetSession(string Key, object value)
        {
            try
            {
                HttpContext.Current.Session.Set(Key, ObjectToBytes(value));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary> 
        /// 将一个object对象序列化，返回一个byte[]         
        /// </summary> 
        /// <param name="obj">能序列化的对象</param>         
        /// <returns></returns> 
        private static byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter(); formatter.Serialize(ms, obj); return ms.GetBuffer();
            }
        }
        /// <summary> 
        /// 将一个序列化后的byte[]数组还原         
        /// </summary>
        /// <param name="Bytes"></param>         
        /// <returns></returns> 
        private static object BytesToObject(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                IFormatter formatter = new BinaryFormatter(); return formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// 清除所有的Session
        /// </summary>
        /// <returns></returns>
        public static bool ClearSession()
        {
            try
            {
                HttpContext.Current.Session.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }



 
}
