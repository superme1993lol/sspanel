using ClientWeb.Core;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.client;
using Common.Web;
using Service;

namespace ClientWeb.Controllers
{
    public class UserController : BaseController
    {
        MemberDAL md = new MemberDAL();
        NewsDAL nd = new NewsDAL();
        PayOrderDAL pod = new PayOrderDAL();
        WorkOrderDAL wod = new WorkOrderDAL();
        ProductDAL pd = new ProductDAL();
        Purchase pur = new Purchase();
        

        /// <summary>
        /// 激活账户
        /// </summary>
        /// <returns></returns>
        public IActionResult ActiveAccount()
        {
            var code = ReqPara("code");
            if (code.IsNullOrEmpty())
            {
                return Redirect("/Home/Error?msg=激活码为空！");
            }
            md.dbcontext = dbcontextWeb;
            var m = md.GetByRegCode(code);
            if (m == null)
            {
                return Redirect("/Home/Error?msg=账户不存在！");
            }
            if (m.IsRegist == 1)
            {
                return Redirect("/Home/Error?msg=该账户已经被激活过，不需要再次激活！");
            }
            m.IsRegist = 1;
            var db = new DBRepository<Member>(dbcontextWeb);
            if (db.Update(m, true))
            {
                Passport.SetPassport(Project.LoginKey, m);
                return Redirect("/User/Main");
            }
            else
            {
                return Redirect("/Home/Error?msg=提交保存失败");
            }
        }



        /// <summary>
        /// 用户中心首页
        /// </summary>
        /// <returns></returns>
        [MemberPower]
        public IActionResult Main()
        {
            var temppath = AppContext.BaseDirectory + "template/html/user/main.tpl";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            var temppath = AppContext.BaseDirectory + "template/html/user/login.tpl";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }


        /// <summary>
        /// 登录提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult LoginSubmit()
        {
            string username = ReqPara("Account");
            string pwd = ReqPara("pwd");
            string error = "";
            md.dbcontext = dbcontextWeb;
            var u = md.Login(username, pwd, ref error);
            if (u != null)
            {
                Passport.SetPassport(Project.LoginKey, u);
            } 
            else
            {
                return Redirect("/User/Login?msg=" + error);
            }

            if (string.IsNullOrEmpty(ReqPara("reurl")))
                return Redirect("/User/Main");
            else return Redirect(ReqPara("reurl"));
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginOut()
        {
            Passport.ClearPassport();
            var gourl = ReqPara("go");
            if (gourl.IsNullOrEmpty())
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect(gourl);
            }
            
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public IActionResult Regist()
        {
            var temppath = AppContext.BaseDirectory + "template/html/user/regist.tpl";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

        /// <summary>
        /// 提交注册
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegistSubmit()
        {
            string username = ReqPara("Account");
            string pwd = ReqPara("pwd");
            string repwd = ReqPara("repwd");
            string vcode = ReqPara("vcode");
        
            if(!username.IsEmail())
            {
                return Redirect("/User/Regist?msg=请输入正确的邮箱");
            }
            if(pwd.Length<6)
            {
                return Redirect("/User/Regist?msg=密码位数至少6位");
            }
            if(pwd!=repwd)
            {
                return Redirect("/User/Regist?msg=请输入一致的密码");
            } 
            var vcode1= Passport.GetPassport("vocde").ToString();
            if(vcode.ToLower()!=vcode1.ToLower())
            {
                return Redirect("/User/Regist?msg=请输入正确的验证码");
            }

            md.dbcontext = dbcontextWeb;
            if(md.GetByEmail(username) !=null)
            {
                return Redirect("/User/Regist?msg=该邮箱已注册过");
            }


            var RegistKey = Guid.NewGuid().ToString();
            var Sspwd = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10); 
            //var Ssport = 65536+ md.GetMaxId(); //在创建订单的时候判断并生成

            if(Service.EmailService.SendActiveEmail(username, RegistKey, Program.Domain, dbcontextWeb))
            {
                Member m = new Member()
                {
                    Account = username,
                    CreateTime = DateTime.Now,
                    Email = username,
                    IsMailSend=1,
                    IsRegist = 0,
                    IsUse = 1,
                    Pwd = Common.Str.MD5Encrypt.MD5Deal(pwd),
                    RegistKey = RegistKey 
                };
                var db = new DBRepository<Member>(dbcontextWeb);
                if(db.Add(m,true))
                {
                    return Redirect("/User/Login?msg=邮件发送成功，请前往激活");
                }
                else
                {
                    return Redirect("/User/Regist?msg=保存至数据库失败，请重新尝试");
                }

            }
            else
            {
                return Redirect("/User/Regist?msg=邮件发送失败，请重新尝试");
            }
             
        }

        /// <summary>
        /// 支付记录
        /// </summary>
        /// <returns></returns>
        [MemberPower]
        public IActionResult PayLog()
        {
            var temppath = AppContext.BaseDirectory + "template/html/user/paylog.tpl";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

        [MemberPower]
        public IActionResult WorkOrderList()
        {
            var temppath = AppContext.BaseDirectory + "template/html/user/workorderlist.tpl";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

        [MemberPower]
        public IActionResult WorkOrderDetail()
        {
            var temppath = AppContext.BaseDirectory + "template/html/user/workorderdetail.tpl";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

        [MemberPower]
        public IActionResult MemberService()
        {
            var temppath = AppContext.BaseDirectory + "template/html/user/memberservice.tpl";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

        /// <summary>
        /// 服务详细
        /// </summary>
        /// <returns></returns>
        [MemberPower]
        public IActionResult MemberServiceDetail()
        {
            var id = ReqPara("cid");

            if(!id.IsInt())
            {
                return View();
            }
            md.dbcontext = dbcontextWeb;
            var ms= md.GetServiceById(id.ToInt().Value);
            if(ms==null)
            {
                return View();
            }


            var temppath = AppContext.BaseDirectory + "template/html/user/memberservicedetail.tpl";
            var html = Common.MyFile.GetFileString(temppath);

            List<KeyValuePair<string, string>> slst = new List<KeyValuePair<string, string>>();

            slst.Add(new KeyValuePair<string, string>("Domain", Program.Domain));
            slst.Add(new KeyValuePair<string, string>("token", ms.Token));

            ViewBag.html = RenderPage(html, slst);
            return View();
        }

        /// <summary>
        /// 继续服务
        /// </summary>
        /// <returns></returns>
        [MemberPower]
        public IActionResult ContinueService()
        {
            var id = ReqPara("id");
            if (!id.IsInt())
            {
                return Redirect("/User/MemberService?msg=参数不能为空");
            }
            md.dbcontext = dbcontextWeb;
            pd.dbcontext = dbcontextWeb;
            pod.dbcontext = dbcontextWeb;
            var ms = md.GetServiceById(id.ToInt().Value);
            if (ms == null)
            {
                return Redirect("/User/MemberService?msg=续费的服务不存在");
            }
            if(ms.EndTime<DateTime.Now)
            {
                return Redirect("/User/MemberService?msg=服务已经过期，请重新购买");
            }
            var userid = user.Id;
            //第一步，创建订单
            Payorder po = new Payorder()
            {
                CreateTime = DateTime.Now,
                IsNew = 0,
                MemberId = userid,
                Money =ms.Price,
                PayWay = 1,
                ProId = ms.ProId,
                State = 1,
                OutTime = DateTime.Now.AddHours(1),
                OrderNum = Guid.NewGuid().ToStr(),
                 MemberServiceId=ms.Id
            };


            var dbpo = new DBRepository<Payorder>(dbcontextWeb);
            if (dbpo.Add(po, true))
            {
                //第二步，开启支付流程
                var pay = Program.CreatePay();
                bool ismobile = false;
                var po1 = pod.GetByOrderNum(po.OrderNum);
                string rt1 = pay.BuildPay(po.OrderNum, po.Money, "1", Program.Domain, ismobile, po1, dbcontextWeb);
                if (rt1.StartsWith("error:"))
                {
                    var error = rt1.Replace("error:", "");
                    return Redirect("/User/MemberService?msg=" + rt1);
                }
                else if (rt1.StartsWith("url:"))
                {
                    var url = rt1.Replace("url:", "");
                    return Redirect(url);
                }
                else if (rt1.StartsWith("html:"))
                {
                    var html = rt1.Replace("html:", "");
                    var temppath = AppContext.BaseDirectory + "template/html/user/continueservice.tpl";
                    var html1 = Common.MyFile.GetFileString(temppath);
                    var selfkv = new List<KeyValuePair<string, string>>();
                    selfkv.Add(new KeyValuePair<string, string>("html", html));
                    ViewBag.html = RenderPage(html1, selfkv);
                }
                return View();
            }
            else
            {
                return Redirect("/User/MemberService?msg=保存到数据库失败");
            } 
        }

        /// <summary>
        /// 新增服务
        /// </summary>
        /// <returns></returns>
        [MemberPower]
        public IActionResult AddService()
        {
            var id = ReqPara("id");
            if(!id.IsInt())
            {
                return Redirect("/User/MemberService?msg=参数不能为空");
            }
            pd.dbcontext = dbcontextWeb;
            pod.dbcontext = dbcontextWeb;
            var p = pd.GetById(id.ToInt().Value);
            if(p==null)
            {
                return Redirect("/User/MemberService?msg=购买的服务不存在");
            }
            var userid = user.Id;
            //第一步，创建订单
            Payorder po = new Payorder()
            {
                CreateTime = DateTime.Now,
                IsNew = 1,
                MemberId = userid,
                Money = p.Price,
                PayWay = 1,
                ProId = p.Id,
                State = 1,
                OutTime = DateTime.Now.AddHours(1),
                OrderNum = Guid.NewGuid().ToStr()
            };
            var dbpo = new DBRepository<Payorder>(dbcontextWeb);
            if(dbpo.Add(po,true))
            { 
                //第二步，开启支付流程
                var pay = Program.CreatePay();
                bool ismobile = false;
                var po1 = pod.GetByOrderNum(po.OrderNum);
                string rt1 = pay.BuildPay(po.OrderNum, po.Money, "1" , Program.Domain, ismobile, po1,dbcontextWeb);
                if (rt1.StartsWith("error:"))
                {
                    var error = rt1.Replace("error:", "");
                    return Redirect("/User/MemberService?msg="+rt1);
                }
                else if (rt1.StartsWith("url:"))
                { 
                    var url = rt1.Replace("url:", ""); 
                    return Redirect(url); 
                }
                else if (rt1.StartsWith("html:"))
                {
                    var html = rt1.Replace("html:", "");
                    var temppath = AppContext.BaseDirectory + "template/html/user/addservice.tpl";
                    var html1 = Common.MyFile.GetFileString(temppath);
                    var selfkv = new List<KeyValuePair<string, string>>();
                    selfkv.Add(new KeyValuePair<string, string>("html", html));
                    ViewBag.html = RenderPage(html1, selfkv);
                }
                return View();
            }
            else
            {
                return Redirect("/User/MemberService?msg=保存到数据库失败");
            }
             
        }

        [MemberPower]
        public IActionResult NewsList()
        {
            var temppath = AppContext.BaseDirectory + "template/html/user/newslist.tpl";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

         


        #region 接口类型数据
        /// <summary>
        /// 当前用户
        /// </summary>
        /// <returns></returns>
        public IActionResult GetCurrentUser()
        {
            if (Passport.GetPassport(Project.LoginKey) != null)
            {
                Member u = Passport.GetPassport(Project.LoginKey) as Member;
                return Json(Success(ToJson(new
                {
                    Msg = u.Email
                })));
            }
            else
            {
                return Json(Success(ToJson(new
                {
                    Msg = ""
                })));
            }
        }

        /// <summary>
        /// 最新公告
        /// </summary>
        /// <returns></returns>
        [MemberPower]
        public IActionResult GetLastNews()
        {
            nd.dbcontext = dbcontextWeb;
            var n = nd.GetLastNews();
            if(n==null)
            {
                return Json(Success(ToJson(new
                {
                   Content="暂无",
                   CreateTime= "暂无",
                   Title= "暂无"
                })));
            }
            else
            {
                return Json(Success(ToJson(new
                {
                    Content = n.Content,
                    CreateTime = n.CreateTime.ToStr("yyyy-MM-dd HH:mm:ss"),
                    Title = n.Title
                })));
            }

        }


        [MemberPower]
        public IActionResult GetAllMemberService()
        {
            
            var userid = user.Id;
            md.dbcontext = dbcontextWeb;

            //  查询当前已经使用的流量
            var mslst = md.GetServiceByMemberId(userid).Select(p => new
            {
                EndTime = p.EndTime.ToStr("yyyy-MM-dd"),
                NextDueTime = p.NextDueTime.ToStr("yyyy-MM-dd"),
                Traffic = p.Traffic / (1024 * 1024 * 1024),
                UsedTraffic = SsDbService.GetServiceAllTraffic(p.Id, dbcontextSs) / (1024 * 1024 * 1024),
                p.Id
            }).ToList();
            if (mslst!=null)
            {
                return Json(Success(ToJson(new
                {
                    mslst = mslst
                })));
            }
            else
            {
                return Json(Success(ToJson(new
                {
                    mslst = ""
                })));
            }

        }

        int pagesize = 15;

        [MemberPower]
        public IActionResult GetPayOrderPageMax()
        {
            var userid = user.Id;
            pod.dbcontext = dbcontextWeb;
            var count = pod.GetCountByMemberId(userid,9);
            var num = count / pagesize;
            if(count % pagesize>0)
            {
                num++;
            }
            if(num==0)
            {
                num = 1;
            }
            return Json(Success(ToJson(new
            {
                count = num
            })));
        }

        [MemberPower]
        public IActionResult GetPayOrder()
        {
            var userid = user.Id;
            
            var pageindex = 1;
            if(ReqPara("pageindex").IsInt())
            {
                pageindex = ReqPara("pageindex").ToInt().Value;
            }
            

            var dbpo = new DBRepository<Payorder>(dbcontextWeb).DbQuery.Where(p=>p.MemberId==userid&&p.State==9).OrderByDescending(p=>p.CreateTime);
            var lst = dbpo.Skip((pageindex - 1) * pagesize).Take(pagesize).Select(p => new {p.Id, p.Money,p.Pro.ProName,p.PayWay,p.FinishTime  }).ToList().Select(p=>new {p.Id,Money=p.Money/100.0,p.ProName, PayWay= GetPayWay(p.PayWay), FinishTime=p.FinishTime.Value.ToStr() }).ToList();

            return Json(Success(ToJson(new
            {
                list= lst
            })));
           
        }

        /// <summary>
        /// 支付方式
        /// </summary>
        /// <param name="payway"></param>
        /// <returns></returns>
        public string GetPayWay(int payway)
        {
            switch (payway)
            {
                case 1: return "支付宝"; break;
                case 2: return "微信"; break;
               default: return "其他"; break;
            }

        }




        [MemberPower]
        public IActionResult GetWorkOrderPageMax()
        {
            var userid = user.Id;
            wod.dbcontext = dbcontextWeb;
            var count = wod.GetCountByMemberId(userid);
            var num = count / pagesize;
            if (count % pagesize > 0)
            {
                num++;
            }
            if (num == 0)
            {
                num = 1;
            }
            return Json(Success(ToJson(new
            {
                count = num
            })));
        }



        [MemberPower]
        public IActionResult GetWorkOrder()
        {
            var userid = user.Id;

            var pageindex = 1;
            if (ReqPara("pageindex").IsInt())
            {
                pageindex = ReqPara("pageindex").ToInt().Value;
            }


            var dbpo = new DBRepository<Workorder>(dbcontextWeb).DbQuery.Where(p => p.MemberId == userid ).OrderByDescending(p => p.CreateTime);
            var lst = dbpo.Skip((pageindex - 1) * pagesize).Take(pagesize).Select(p => new { p.Id, p.Content, p.State, p.CreateTime }).ToList().Select(p => new { p.Id, p.Content, State=(p.State==1?"进行中":"已关闭"), CreateTime=p.CreateTime.ToStr() }).ToList();

            return Json(Success(ToJson(new
            {
                list = lst
            })));

        }



        [MemberPower]
        public IActionResult GetWorkOrderById()
        {
            var userid = user.Id;
            wod.dbcontext = dbcontextWeb;

            if (!ReqPara("cid").IsInt())
            {
                return Json(Fail("参数为空"));
            }
            var wo = wod.GetById(ReqPara("cid").ToInt().Value);
            if(wo==null)
            {
                return Json(Fail("数据不存在"));
            }
            if(wo.MemberId!=userid)
            {
                return Json(Fail("您没有权限"));
            }

             var dlst= wod.GetDetailsByWoId(wo.Id).OrderBy(p=>p.CreateTime).Select(p=>new  { p.Content, WodType=p.WodType==1?"您": "回复", CreateTime= p.CreateTime.ToStr()}).ToList();

            return Json(Success(ToJson(new
            {
                Content = wo.Content,
                CreateTime = wo.CreateTime.ToStr("yyyy-MM-dd HH:mm:ss"),
                State=wo.State==1? "进行中" : "已关闭",

                dlst= dlst
            }))); ; 
        }



        [HttpPost]
        [MemberPower]
        public IActionResult WorkOrderReplySubmit()
        {
            var cid = ReqPara("cid");
          
            var ReplyContent = ReqPara("ReplyContent");
            if (ReplyContent.IsNullOrEmpty())
            {
                return Json(Fail("请输入回复内容"));
            }
            wod.dbcontext = dbcontextWeb;
            if (cid.IsInt())
            {
                var v = wod.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                var db = new DBRepository<Workorderdetail>(dbcontextWeb);
                var wd = new Workorderdetail()
                {
                    WodType = 1,
                    Content = ReplyContent,
                    CreateTime = DateTime.Now,
                    Woid = v.Id
                };
                if (db.Add(wd, true))
                {
                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
                else
                {
                    return Json(Fail("提交保存失败"));
                }
            }
            else
            {
                return Json(Fail("参数id不正确"));
            }



        }

        [HttpPost]
        [MemberPower]
        public IActionResult WorkOrderAddSubmit()
        {
            var Content = ReqPara("addcontent");
            var dbq = new DBRepository<Workorder>(dbcontextWeb);
            Workorder wo = new Workorder() {
             Content=Content,
              CreateTime=DateTime.Now,
               MemberId=user.Id,
                State=1
            };
            if(dbq.Add(wo,true))
            {
                return Json(Success(ToJson(new
                {
                    Msg = ""
                })));
            }
            else
            {
                return Json(Fail("保存失败"));
            }

        }





        [MemberPower]
        public IActionResult GetNewsPageMax()
        {
            var userid = user.Id;
            nd.dbcontext = dbcontextWeb;
            var count = nd.GetCountInUse();
            var num = count / pagesize;
            if (count % pagesize > 0)
            {
                num++;
            }
            if (num == 0)
            {
                num = 1;
            }
            return Json(Success(ToJson(new
            {
                count = num
            })));
        }



        [MemberPower]
        public IActionResult GetNews()
        {
            var userid = user.Id;

            var pageindex = 1;
            if (ReqPara("pageindex").IsInt())
            {
                pageindex = ReqPara("pageindex").ToInt().Value;
            }


            var dbpo = new DBRepository<News>(dbcontextWeb).DbQuery.Where(p => p.IsUse == 1).OrderByDescending(p => p.CreateTime);
            var lst = dbpo.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList().Select(p => new { p.Id, Content= p.Content.Replace("'","\'"),p.Title, CreateTime = p.CreateTime.ToStr() }).ToList();

            return Json(Success(ToJson(new
            {
                list = lst
            })));

        }
        #endregion


    }
}
