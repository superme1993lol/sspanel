using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.client;
using Model;
using DAL;

namespace Service.Pay
{
    public class MugglePay:BasePay
    {
        public string MugApiTolen = "";
        public string MugApiDomain = ""; //麻瓜宝接口域名，不用带https://

        public MugglePay(string _MugApiTolen)
        {
            MugApiTolen = _MugApiTolen;
        }

        public override string BuildPay(string orderNum, int orderFee, string payway, string domain,  bool ismobile = false, Payorder po = null, stclientContext dbcontextWeb = null)
        {
          
            string url = "https://"+ MugApiDomain + "/v1/orders";
            string titelAdd = "";
            string pay_currency = "ALIPAY";// "ALIGLOBAL";
            switch (payway)
            {
                case "1": titelAdd = "支付宝"; pay_currency = "ALIPAY"; break;
                case "2": titelAdd = "微信"; pay_currency = "WECHAT"; break;
            }
            var callbackhost = (domain.StartsWith("http") ? "https://" : "") + domain;

            string callback_url = callbackhost + "/Pay/Notify";
            string cancel_url = callbackhost + "/Pay/Finish?onum=" + orderNum;
            string success_url = callbackhost + "/Pay/Finish?onum=" + orderNum; 
            var body = new
            {
                merchant_order_id = orderNum,
                price_amount = orderFee / 100.0,
                price_currency = "CNY",
                pay_currency = pay_currency,
                title = titelAdd + "支付",
                description = "",
                callback_url = callback_url,
                cancel_url = cancel_url,
                success_url = success_url,
                mobile = ismobile
            };
            Hashtable h = new Hashtable();
            h["token"] = MugApiTolen;

            var rt = Common.Json.ClassJson.JsonToDynamic(Post(url, Common.Json.ClassJson.ClassToJson(body), h, "application/json"));
            if (rt.error != null)
            {
                string error = rt.error;
                return "error:" + error;
            }
            else
            {
                string payment_url = rt.payment_url;
                po.TransactionNum = rt.order.order_id;
                var dbpo = new DBRepository<Payorder>(dbcontextWeb);
                if (dbpo.Update(po, true))
                {
                    return "url:" + payment_url;
                }
                else
                {
                    return "error:保存到数据库失败";
                }  
            }
        }

       
        public override string GetOrderStatus(string ordernum, stclientContext dbcontextWeb)
        {
            PayOrderDAL pod = new PayOrderDAL();
            pod.dbcontext = dbcontextWeb;
            var po = pod.GetByOrderNum(ordernum);
            var oid = po.TransactionNum;

            return GetOrderStatus(oid);
        }

        private string GetOrderStatus(string oid)
        {
            string url = "https://"+ MugApiDomain + "/v1/orders/" + oid;
            Common.Web.WebRequest wr = new Common.Web.WebRequest();

            Hashtable h = new Hashtable();
            h["token"] = MugApiTolen;

            var rt = Common.Json.ClassJson.JsonToDynamic(Get(url, h, "application/json"));
            if (rt.error != null)
            {
                string error = rt.error;
                return "error:" + error;
            }
            else
            {
                string status = rt.order.status;
                if (status == "PAID" || status == "RESOLVED")
                {
                    //已经支付完成
                    status = "1";
                }
                else
                {
                    status = "0";
                }
                return "status:" + status;
            }
        }

        public override string GetOrderNumKey()
        { 
            return "onum";
        }

        public override string NotifySuccess()
        {
            return Common.Json.ClassJson.ClassToJson(new { status = 200 });
        }
        public override string NotifyFail()
        {
            return Common.Json.ClassJson.ClassToJson(new { status = 400 });
        }
        public override string NotifyOrderNumKey()
        {
            return "merchant_order_id";
        }
        public override string NotifyOrderIdKey()
        {
            return "order_id";
        }
        public override string NotifyStatusKey()
        {
            return "status";
        }

        public override string NotifyCheck(string ordernum, string orderid, string status)
        { 
            if (status == "PAID" || status == "RESOLVED")
            {
                var rt = GetOrderStatus(orderid);

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
