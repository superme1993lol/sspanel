using System;
using System.Runtime.Caching;

namespace Common.MyCache
{
    /// <summary>
    /// 缓存信息保存(内存缓存)
    /// </summary>
    public class MyCache
    {
        #region 头部代码
        /// <summary>
        /// 头部代码 
        /// </summary>
        private static string myCacheHeadName = "";

        /// <summary>
        /// 头部代码 
        /// </summary>
        public static string MyCacheHeadName
        {
            get
            {
                return myCacheHeadName;
            }
            set
            {
                myCacheHeadName = value;
            }
        }
        #endregion

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <param name="experiedTime">间隔时间</param>
        /// <returns></returns>
        public static bool SetCache(string key, object value, TimeSpan experiedTime)
        {
            try
            {
                key = MyCacheHeadName + key;
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.Add(experiedTime);
                if (MemoryCache.Default.Contains(key, null))
                {
                    MemoryCache.Default.Set(key, value, policy);
                }
                else
                {
                    MemoryCache.Default.Add(key, value, policy);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <param name="experiedTime">间隔时间</param>
        /// <returns></returns>
        public static bool SetCache(string key, object value, DateTime endtime)
        {
            try
            {
                key = MyCacheHeadName + key;
                CacheItemPolicy policy = new CacheItemPolicy();
                DateTimeOffset dto = endtime;
                policy.AbsoluteExpiration = dto;
                if (MemoryCache.Default.Contains(key, null))
                {
                    MemoryCache.Default.Set(key, value, policy);
                }
                else
                {
                    MemoryCache.Default.Add(key, value, policy);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool SetCache(string key, object value)
        {
            try
            {
                key = MyCacheHeadName + key;
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.Priority = CacheItemPriority.NotRemovable;
                if (MemoryCache.Default.Contains(key, null))
                {
                    if(value==null) 
                    {
                        MemoryCache.Default.Remove(key);
                    }
                    else
                    {
                        MemoryCache.Default.Set(key, value, policy);
                    } 
                }
                else
                {
                    if (value != null)
                    {
                        MemoryCache.Default.Set(key, value, policy);
                    } 
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>缓存对象</returns>
        public static object GetCache(string key)
        {
            try
            {
                key = MyCacheHeadName + key;
                return MemoryCache.Default[key];
            }
            catch
            {
                return null;
            }
        }
    }
}
