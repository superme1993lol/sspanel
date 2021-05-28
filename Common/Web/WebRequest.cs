using Common.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace Common.Web
{
    /// <summary>
    /// Web请求
    /// </summary>
    public class WebRequest
    {
        private readonly WebProxy _proxy;
        private CookieContainer _cookieContainer = new CookieContainer();
        private bool _noCookie;
        private bool _autoRedirect = true;
        private HttpWebResponse _response = null;

        /// <summary>
        /// 获取或设置Http请求Cookie
        /// </summary>
        public CookieContainer CookieContainer
        {
            get { return _cookieContainer; }
            set { _cookieContainer = value; }
        }

        /// <summary>
        /// 指示Http请求是否携带Cookie
        /// </summary>
        public bool NoCookie
        {
            get { return _noCookie; }
            set { _noCookie = value; }
        }

        /// <summary>
        /// 指示Http请求是否自动跳转
        /// </summary>
        public bool AutoRedirect
        {
            get { return _autoRedirect; }
            set { _autoRedirect = value; }
        }

        /// <summary>
        /// 默认不使用代理
        /// </summary>
        public WebRequest()
        {
            _proxy = null;
        }

        /// <summary>
        /// 使用Http代理(不需要身份验证)
        /// </summary>
        /// <param name="proxyAddress">代理服务器IP地址:端口</param>
        public WebRequest(string proxyAddress)
        {
            _proxy = new WebProxy { Address = new Uri("http://" + proxyAddress) };
        }

        /// <summary>
        /// 使用Http代理
        /// </summary>
        /// <param name="proxyAddress">代理地址</param>
        /// <param name="proxyAccount">代理帐号</param>
        /// <param name="proxyPassword">代理密码</param>
        public WebRequest(string proxyAddress, string proxyAccount, string proxyPassword)
        {
            _proxy = new WebProxy
            {
                Address = new Uri(proxyAddress),
                BypassProxyOnLocal = true,
                Credentials = new NetworkCredential(proxyAccount, proxyPassword)
            };
        }

        /// <summary>
        /// 发起GET请求
        /// </summary>
        /// <param name="url">请求链接</param>
        /// <param name="referer">请求来源</param>
        public string Get(string url, string referer = "")
        {
            List<string[]> headers = new List<string[]>
            {
                new[] {"Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"},
                new[] {"Accept-Encoding", "gzip, deflate"},
                new[] {"Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3"},
                new[] {"Referer", referer},
                new[]
                {
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.27 Safari/537.36"
                }
            };
            try
            {
                string htmlStr = "";
                var s = GetResponseStream(url, "GET", null, headers);
                using (
                    StreamReader sr = new StreamReader(s, Encoding.UTF8))
                    //  Encoding.GetEncoding("GB2312")))
                    htmlStr = sr.ReadToEnd();
                return htmlStr;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (_response != null)
                {
                    _response.Close();
                }
            }
        }

        /// <summary>
        /// 发起POST请求
        /// </summary>
        /// <param name="url">请求链接</param>
        /// <param name="param">请求数据</param>
        /// <param name="referer">请求来源</param>
        public string Post(string url, string param, string referer = "")
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            CookieContainer cookie = request.CookieContainer;//如果用不到Cookie，删去即可  
                                                             //以下是发送的http头，随便加，其中referer挺重要的，有些网站会根据这个来反盗链  
            request.Referer = "";
            request.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
            request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
            request.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
            request.KeepAlive = true;
            //上面的http头看情况而定，但是下面俩必须加  
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            Encoding encoding = Encoding.UTF8;//根据网站的编码自定义  
            byte[] postData = encoding.GetBytes(param);//postDataStr即为发送的数据，格式还是和上次说的一样  
            request.ContentLength = postData.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            //如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可  
            if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
            {
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            }

            StreamReader streamReader = new StreamReader(responseStream, encoding);
            string retString = streamReader.ReadToEnd();

            streamReader.Close();
            responseStream.Close();

            return retString;


            //List<string[]> headers = new List<string[]>
            //{
            //    new[] {"Accept", "application/json, text/javascript, */*; q=0.01"},
            //    new[] {"Accept-Encoding", "gzip, deflate"},
            //    new[] {"Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3"},
            //    new[] {"Authorization", "CPC"},
            //    new[] {"Cache-Control", "no-cache"},
            //    new[] {"Content-Length", param.Length.ToString(CultureInfo.InvariantCulture)},
            //    new[] {"Content-Locale", "zh_CN"},
            //    new[] {"Content-Type", "application/x-www-form-urlencoded; charset=UTF-8"},
            //    new[] {"Pragma", "no-cache"},
            //    new[] {"Referer", referer},
            //    new[] {"User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:29.0) Gecko/20100101 Firefox/29.0"}
            //};
            //try
            //{
            //    string htmlStr = "";
            //    using (StreamReader sr = new StreamReader(GetResponseStream(url, "POST", param, headers)))
            //        htmlStr = sr.ReadToEnd();
            //    return htmlStr;
            //}
            //catch
            //{
            //    return null;
            //}
            //finally
            //{
            //    if (_response != null)
            //    {
            //        _response.Close();
            //    }
            //}
        }

        /// <summary>
        /// 发起请求
        /// </summary>
        /// <param name="url">请求链接</param>
        /// <param name="method">请求方法</param>
        /// <param name="param">请求数据</param>
        /// <param name="headers">请求头</param>
        private Stream GetResponseStream(string url, string method, string param, List<string[]> headers)
        {
            try
            {
                if (!url.StartsWith("http") && !url.StartsWith("https"))
                {
                    url = "http://" + url;
                }
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                if (request == null) return null;
                request.ServicePoint.ConnectionLimit = 512;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.AllowWriteStreamBuffering = false;
                request.AllowAutoRedirect = _autoRedirect;

                request.Method = method;
                if (_noCookie)
                    _cookieContainer = new CookieContainer();

                request.CookieContainer = _cookieContainer;
                request.Proxy = _proxy;
                request.Timeout = 8000;
                request.KeepAlive = true;

                //循环写入header
                headers.ForEach(header =>
                {
                    switch (header[0])
                    {
                        case "Accept":
                            request.Accept = header[1];
                            break;
                        case "Host":
                            request.Host = header[1];
                            break;
                        case "User-Agent":
                            request.UserAgent = header[1];
                            break;
                        case "Content-Length":
                            request.ContentLength = long.Parse(header[1]);
                            break;
                        case "Content-Type":
                            request.ContentType = header[1];
                            break;
                        case "Referer":
                            request.Referer = header[1];
                            break;
                        default:
                            request.Headers.Add(header[0], header[1]);
                            break;
                    }
                });

                //Post数据
                if (method == "POST")
                {
                    byte[] postData = Encoding.ASCII.GetBytes(param);
                    request.ContentLength = postData.Length;
                    Stream outputStream = request.GetRequestStream();
                    outputStream.Write(postData, 0, postData.Length);
                    outputStream.Close();
                }

                //接收返回数据
                _response = request.GetResponse() as HttpWebResponse;

                if (_response == null) return null;
                Stream responseStream = _response.GetResponseStream();

                //解压
                if (_response.ContentEncoding!=null&& _response.ContentEncoding.ToLower().Contains("gzip"))
                    if (responseStream != null)
                        responseStream = new GZipStream(responseStream, CompressionMode.Decompress, true);

                return responseStream;
            }
            catch (WebException)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取当前CookieContainer中的Cookie
        /// </summary>
        /// <returns>Cookie列表</returns>
        public List<Cookie> GetCurrentCookies()
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)_cookieContainer.GetType().InvokeMember("m_domainTable",
                BindingFlags.NonPublic | BindingFlags.GetField |
                BindingFlags.Instance, null, _cookieContainer, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    BindingFlags.NonPublic | BindingFlags.GetField
                    | BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    lstCookies.AddRange(colCookies.Cast<Cookie>());
            }
            return lstCookies;
        }



        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public string GetHostAddress()
        {
            try
            {
                //string userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                //if (!string.IsNullOrEmpty(userHostAddress))
                //{
                // if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                var userHostAddress = HttpContext.Current.Request.Headers["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                //}
                if (string.IsNullOrEmpty(userHostAddress))
                {
                    userHostAddress = HttpContext.Current.Connection.RemoteIpAddress.ToString();
;
                }

                //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
                if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
                {
                    return userHostAddress;
                }
                return "127.0.0.1";





                #region 老代码
                //string userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                //if (string.IsNullOrEmpty(userHostAddress))
                //{
                //    if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                //        userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                //}
                //if (string.IsNullOrEmpty(userHostAddress))
                //{
                //    userHostAddress = HttpContext.Current.Request.UserHostAddress;
                //}

                ////最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
                //if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
                //{
                //    return userHostAddress;
                //}
                //return "127.0.0.1";
                #endregion
            }
            catch(Exception ex)
            {
                return "127.0.0.1";
            }
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
}
