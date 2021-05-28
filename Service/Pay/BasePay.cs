using Common.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model.client;

namespace Service.Pay
{
    public class BasePay
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="orderFee"></param>
        /// <param name="payway"></param>
        /// <param name="domain"></param>
        /// <param name="paytoken"></param>
        /// <param name="ismobile"></param>
        /// <returns></returns>
        public virtual string BuildPay(string orderNum, int orderFee, string payway, string domain, bool ismobile = false,Payorder po=null,stclientContext dbcontextWeb=null)
        {
            return ""; 
        }

        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="paytoken"></param>
        /// <returns></returns>
        public virtual string GetOrderStatus(string ordernum, stclientContext dbcontextWeb)
        {
            return "";
        }


        public virtual string GetOrderNumKey()
        {
            return "";
        }


        public virtual string NotifySuccess()
        {
            return "";
        }
        public virtual string NotifyFail()
        {
            return "";
        }


        public virtual string NotifyStatusKey()
        {
            return "";
        }
        public virtual string NotifyOrderNumKey()
        {
            return "";
        }
        public virtual string NotifyOrderIdKey()
        {
            return "";
        }
       

        public virtual string NotifyCheck(string ordernum,string orderid,string status )
        {
            return "";
        }


        #region WebRequest提交
        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public string Post(string url, Dictionary<string, string> dic, Hashtable header, string contentType = "application/x-www-form-urlencoded")
        {
            string result = string.Empty;
            HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create(url);
            req.Method = "POST";

            if (header != null && header.Count > 0)
            {
                var keyLst = header.Keys.Cast<string>().ToList();
                for (var s = 0; s < header.Count; s++)
                {
                    var v = header[keyLst[s]].ToString();
                    req.Headers[keyLst[s]] = v;
                }

            }
            req.ContentType = contentType;

            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }


        /// <summary>
        /// POST整个字符串到URL地址中
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="jsonParas"></param>
        /// <returns></returns>
        public string Post(string Url, string jsonParas, Hashtable header, string contentType = "application/x-www-form-urlencoded")
        {
            string strURL = Url;

            //创建一个HTTP请求 
            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(strURL);
            //Post请求方式 
            request.Method = "POST";
            //内容类型
            if (header != null && header.Count > 0)
            {
                var keyLst = header.Keys.Cast<string>().ToList();
                for (var i = 0; i < header.Count; i++)
                {
                    var v = header[keyLst[i]].ToString();
                    request.Headers[keyLst[i]] = v;
                }

            }
            request.ContentType = contentType;

            //设置参数，并进行URL编码

            string paraUrlCoded = jsonParas;//System.Web.HttpUtility.UrlEncode(jsonParas);  

            byte[] payload;
            //将Json字符串转化为字节 
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength  
            request.ContentLength = payload.Length;
            //发送请求，获得请求流

            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流

            //String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();


            StreamReader sRead = new StreamReader(s);
            string postContent = sRead.ReadToEnd();
            sRead.Close();

            return postContent;//返回Json数据
        }



        public string Get(string Url, Hashtable header, string contentType = "application/x-www-form-urlencoded")
        {
            string strURL = Url;

            //创建一个HTTP请求 
            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(strURL);
            //Post请求方式 
            request.Method = "Get";
            //内容类型
            if (header != null && header.Count > 0)
            {
                var keyLst = header.Keys.Cast<string>().ToList();
                for (var i = 0; i < header.Count; i++)
                {
                    var v = header[keyLst[i]].ToString();
                    request.Headers[keyLst[i]] = v;
                }

            }
            request.ContentType = contentType;


            //发送请求，获得请求流



            //String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();

            StreamReader sRead = new StreamReader(s);
            string postContent = sRead.ReadToEnd();
            sRead.Close();

            return postContent;//返回Json数据
        }

        #endregion


        #region 带参数跳转
        /// <summary>
        /// This method prepares an Html form which holds all data in hidden field in the addetion to form submitting script.
        /// </summary>
        /// <param name="url">The destination Url to which the post and redirection will occur, the Url can be in the same App or ouside the App.</param>
        /// <param name="data">A collection of data that will be posted to the destination Url.</param>
        /// <returns>Returns a string representation of the Posting form.</returns>
        /// <Author>Samer Abu Rabie</Author>
        private String PreparePOSTForm(string url, NameValueCollection data)
        {
            string formID = "PostForm";
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"POST\">");
            foreach (string key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key + "\" value=\"" + data[key] + "\">");
            }
            strForm.Append("</form>");
            return strForm.ToString();
        }
        /// <summary>
        /// POST data and Redirect to the specified url using the specified page.
        /// </summary>
        /// <param name="page">The page which will be the referrer page.</param>
        /// <param name="destinationUrl">The destination Url to which the post and redirection is occuring.</param>
        /// <param name="data">The data should be posted.</param>
        /// <Author>Samer Abu Rabie</Author>
        public string RedirectAndPOST(string destinationUrl, NameValueCollection data)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTForm(destinationUrl, data);
            string formID = "PostForm";
            var html = "<script>parent.$(\"body\").append('" + strForm + "');parent.$(\"#" + formID + "\").submit()</script>";

            return html;
        }

        #endregion 


    }
}
