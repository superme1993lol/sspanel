using AdminWeb.core;
using AdminWeb.Core;
using AdminWeb.Models;
using Common.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Model.admin;
using Model.client;
using Model;

namespace AdminWeb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       [AdminPower]
        public IActionResult Index()
        {
            int regNum = 0;
            int actNum =0;
            int userInUseNum = 0;
            int userNum = 0;
         
            int ordernum = 0;
            int paymoney_today = 0;
            int paymoney_thismonth = 0;
            int paymoney_lastmonth = 0;

            if(clientdbcontext!=null)
            {
                List<dynamic> syslst = new List<dynamic>();
                foreach(var cdb in clientdbcontext)
                {
                    var sysname = cdb.Key;
                    var sysdb = cdb.Value;
                    var dbm = new DBRepository<Member>(sysdb);
                    var dbo = new DBRepository<Payorder>(sysdb);
                    var regNum_ = dbm.DbQuery.Where(p => p.CreateTime >= DateTime.Now.Date).Count();
                    regNum += regNum_;

                    var actNum_ = dbm.DbQuery.Where(p => p.CreateTime >= DateTime.Now.Date && p.IsRegist == 1).Count();
                    actNum += actNum_;


                    var userInUseNum_= dbm.DbQuery.Where(p =>p.Memberservice.Any(s=>s.EndTime>DateTime.Now)).Count();
                    userInUseNum += userInUseNum_;


                    var userNum_= dbm.DbQuery.Where(p => true).Count();
                    userNum += userNum_;

                    var paymoney_today_ = dbo.DbQuery.Where(p => p.CreateTime >= DateTime.Now.Date && p.State == 9).Sum(p => p.Money);
                    paymoney_today += paymoney_today_;

                    var ordernum_ = dbo.DbQuery.Where(p => p.CreateTime >= DateTime.Now.Date && p.State == 9).Count();
                    ordernum += ordernum_;

                    var thism_s = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
                    var lastm_s= new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1);

                    var paymoney_thismonth_= dbo.DbQuery.Where(p => p.CreateTime >= thism_s && p.State == 9).Sum(p => p.Money);
                    paymoney_thismonth += paymoney_thismonth_;

                    var paymoney_lastmonth_ = dbo.DbQuery.Where(p => p.CreateTime >= lastm_s && p.CreateTime < thism_s && p.State == 9).Sum(p => p.Money);
                    paymoney_lastmonth += paymoney_lastmonth_;
                    var cinfo = new {
                        name= sysname,
                        regNum = regNum_,
                        actNum= actNum_,
                        userInUseNum= userInUseNum_,
                        userNum= userNum_,
                        ordernum= ordernum_,
                        paymoney_today= paymoney_today_,
                        paymoney_thismonth= paymoney_thismonth_,
                        paymoney_lastmonth= paymoney_lastmonth_
                    };
                    syslst.Add(cinfo);
                }
                ViewBag.syslst = syslst;
            }

            ViewBag.regNum = regNum;
            ViewBag.actNum = actNum;
            ViewBag.userInUseNum = userInUseNum;
            ViewBag.userNum = userNum; 
            ViewBag.ordernum = ordernum;
            ViewBag.paymoney_today = paymoney_today;
            ViewBag.paymoney_thismonth = paymoney_thismonth;
            ViewBag.paymoney_lastmonth = paymoney_lastmonth;
            return View();
        }

        

        public IActionResult Login()
        {
            
            return View();
        }


        public IActionResult LoginSubmit()
        {
            string username = ReqPara("inputAccount");
            string pwd = ReqPara("inputPassword");
            string error = "";
            var u = aid.Login(username, pwd, ref error);
            if (u != null)
            {
                Passport.SetPassport(Project.LoginKey, u);
            }
            else
            {
                return Redirect("/Home/Login?msg=" + error);
            }

            if (string.IsNullOrEmpty(ReqPara("gourl")))
                return Redirect("/Home/Index");
            else return Redirect(ReqPara("gourl"));
        }


 


    }
}
