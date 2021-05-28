using Model.client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pay
{
    public class BgpPay:BasePay
    {
        public string BgpApiId;
        public string BgpApiTolen;
        public string BgpDomain = ""; //bgppay 接口域名，不用带https://

        public BgpPay(string _BgpApiId,string _BgpApiTolen)
        {
            BgpApiId = _BgpApiId;
            BgpApiTolen = _BgpApiTolen;
        }


        public string MD5Str(string password)
        {
            byte[] result = Encoding.Default.GetBytes(password);     
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "").ToLower();  
        }


        public override string BuildPay(string orderNum, int orderFee, string payway, string domain,  bool ismobile = false, Payorder po = null, stclientContext dbcontextWeb = null)
        {
            string url = "https://" + BgpDomain  + "/submit.php";
            string titelAdd = "";
            string pay_currency = "alipay";// "ALIPAY";
            switch (payway)
            {
                case "1": titelAdd = "支付宝支付"; pay_currency = "alipay"; break;
                case "2": titelAdd = "微信支付"; pay_currency = "wxpay"; break;
            }


            string callback_url = domain + "/pay/Notify";
            string cancel_url = domain + "/pay/Finish";
            string success_url = domain + "/pay/Finish"; 

            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("pid", BgpApiId));
            lst.Add(new KeyValuePair<string, string>("type", pay_currency));
            lst.Add(new KeyValuePair<string, string>("out_trade_no", orderNum));
            lst.Add(new KeyValuePair<string, string>("notify_url", callback_url));
            lst.Add(new KeyValuePair<string, string>("return_url", success_url));
            lst.Add(new KeyValuePair<string, string>("name", titelAdd));
            lst.Add(new KeyValuePair<string, string>("money", (orderFee / 100.00).ToString()));
            lst.Add(new KeyValuePair<string, string>("sitename", domain));

            lst = lst.OrderBy(p => p.Key).ToList();
            NameValueCollection data = new NameValueCollection();

            var parinfo = "";
            foreach (var info in lst)
            {
                if (!parinfo.IsNullOrEmpty())
                {
                    parinfo += "&";
                }
                parinfo += info.Key + "=" + info.Value;
                data.Add(info.Key, info.Value);
            }
            var sign = MD5Str(parinfo + BgpApiTolen);
            data.Add("sign", sign);
            data.Add("sign_type", "MD5");
            var html = RedirectAndPOST(url, data);
            return  "html:"+html;
        }
        public override string GetOrderNumKey()
        {
            return "out_trade_no";
        }

        public override string GetOrderStatus(string ordernum, stclientContext dbcontextWeb)
        {
            return GetOrderStatus(ordernum);
        }

        private string GetOrderStatus(string ordernum)
        {
            string url = "https://" + BgpDomain + "/api.php?act=order&pid=" + BgpApiId + "&key=" + BgpApiTolen + "&out_trade_no=" + ordernum;
            Common.Web.WebRequest wr = new Common.Web.WebRequest();

            var rt = Common.Json.ClassJson.JsonToDynamic(wr.Get(url));
            if (rt.status != 1 && rt.status != 0)
            {
                string error = rt.msg;
                return "error:" + error;
            }
            else
            {
                return "status:" + rt.status;
            }
        }

        public override string NotifySuccess()
        {
            return "success";
        }
        public override string NotifyFail()
        {
            return "fail";
        }
        public override string NotifyStatusKey()
        {
            return "trade_status";
        }
        public override string NotifyOrderNumKey()
        {
            return "out_trade_no";
        }
        public override string NotifyOrderIdKey()
        {
            return "trade_no";
        }

        public override string NotifyCheck(string ordernum, string orderid, string status)
        {
            if(status== "TRADE_SUCCESS")
            { 
                var rt=  GetOrderStatus(ordernum);
               

                if (rt == "status:1")
                {
                    return NotifySuccess();
                }
                else
                {
                    return NotifyFail();
                }
            }
            return NotifyFail();
        }
    }
}
