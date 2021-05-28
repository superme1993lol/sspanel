using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using DAL;
using ClientWeb.Core;

namespace ClientWeb.Controllers
{
    public class PayController : BaseController
    {

        Purchase pur = new Purchase();

        /// <summary>
        /// 异步回调
        /// </summary>
        /// <returns></returns>
        public IActionResult Notify()
        {
            var pay = Program.CreatePay();
            var onum= ReqPara(pay.NotifyOrderNumKey());
            var oid = ReqPara(pay.NotifyOrderIdKey());
            var status = ReqPara(pay.NotifyStatusKey());
            var rt = pay.NotifyCheck(onum,oid,status);
            if(rt==pay.NotifySuccess())
            {
                if(!pur.FinishPay(onum, dbcontextWeb,dbcontextSs))
                {
                    rt = pay.NotifyFail();
                }
            }
         
            var temppath = AppContext.BaseDirectory + "template/html/user/notify.tpl";
            var html1 = Common.MyFile.GetFileString(temppath);
            var selfkv = new List<KeyValuePair<string, string>>();
            selfkv.Add(new KeyValuePair<string, string>("html", rt));
            ViewBag.html = RenderPage(html1, selfkv);
            return View();
        }

      /// <summary>
      /// 完成订单，同步回调
      /// </summary>
      /// <returns></returns>
        public IActionResult Finish()
        {
            var pay = Program.CreatePay();
            var onum = ReqPara(pay.GetOrderNumKey());

            var rt = pay.GetOrderStatus(onum,dbcontextWeb);
            if (rt == "status:1")
            {
                if (!pur.FinishPay(onum, dbcontextWeb, dbcontextSs))
                {
                    return Redirect("/User/MemberService?msg=回调失败");
                }
                return Redirect("/User/MemberService");
            }
            else if(rt.StartsWith("error:"))
            {
                var info = rt.Replace("error:", "");

                return Redirect("/User/MemberService?msg="+ info);
            }
            else
            {
                return Redirect("/User/MemberService?msg=" + rt);
            }
               
        }
    }
}
