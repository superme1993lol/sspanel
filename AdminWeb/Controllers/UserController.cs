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
using DAL;
using Service;

namespace AdminWeb.Controllers
{
    public class UserController : BaseController
    {
        MemberDAL md = new MemberDAL();
        PreferentialCodeDAL pcd = new PreferentialCodeDAL();
        ProductDAL pd = new ProductDAL();
        ChildSystemDAL csd = new ChildSystemDAL();
      

        #region 用户
        [AdminPower]
        public IActionResult UserList()
        {
            int pagesize = 30;
            int? pageindex = Project.ReqPara("pageindex").ToInt();
            int? pagenum = Project.ReqPara("pagenum").ToInt();
            if (pagenum != null)
            {
                pageindex = pagenum;
            }
            else
            {
                pageindex = pageindex == null ? 1 : pageindex.Value;
            }

            var cdb = GetViewDb();
            var Email = ReqPara("Email");
            var isuse = ReqPara("isuse");
            if (isuse.IsNullOrEmpty())
            {
                isuse = "1";
            }
            var dbq = new DBRepository<Member>(cdb).DbQuery;
            if (!Email.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.Email.Contains(Email) || p.Account.Contains(Email));
            }
            if (isuse == "1")
            {
                dbq = dbq.Where(p => p.IsUse == 1);
            }
            else
            {
                dbq = dbq.Where(p => p.IsUse == 0);
            }
            var lst = dbq.OrderByDescending(p => p.CreateTime).Skip((pageindex.Value - 1) * pagesize).Take(pagesize).Distinct().Distinct().ToList();
            ViewBag.pageindex = pageindex;
            ViewBag.pagesize = pagesize;
            ViewBag.Count = dbq.Count();
            ViewBag.List = lst;
            ViewBag.isuse = isuse;
            ViewBag.Email = Email;
            return View();
        }

        [AdminPower]
        public IActionResult UserDetail()
        {
            var cid = ReqPara("cid");

            var cdb = GetViewDb();
            md.dbcontext = cdb;
            var msbq = new DBRepository<Memberservice>(cdb).DbQuery;


            Member v = null;

            if (cid.IsInt())
            {
                v = md.GetById(cid.ToInt().Value);
                if (v != null)
                {
                    ViewBag.cid = v.Id;
                    ViewBag.Account = v.Account;
                    ViewBag.CreateTime = v.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    ViewBag.IsUse = v.IsUse == (short)1 ? "在用" : "停用";
                    ViewBag.IsRegist = v.IsRegist == (short)1 ? "已激活" : "未激活";
                    ViewBag.IsMailSend = v.IsMailSend == (short)1 ? "已发送" : "未发送";
                    ViewBag.Email = v.Email;
                    ViewBag.NickName = v.NickName;
                  
                    var mslst = md.GetServiceByMemberId(v.Id);
                    if (mslst != null)
                    {
                        ViewBag.ms = mslst.Where(p => p.EndTime >= DateTime.Now).ToList();
                    }
                }
            }


            return View();
        }



        [HttpPost]
        [AdminPower]
        public IActionResult ChangeUserSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            md.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = md.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                v.IsUse = v.IsUse == (short)1 ? (short)0 : (short)1;
                var db = new DBRepository<Member>(cdb);
                if (db.Update(v, true))
                {
                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
                else
                {
                    return Json(Fail("修改失败"));
                }
            }
            else
            {
                return Json(Fail("参数id不正确"));
            }
        }




        /// <summary>
        /// 重发注册邮件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AdminPower]
        public IActionResult SendEmailUserSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            md.dbcontext = cdb;
            csd.dbcontext = admindbcontext;
            if (cid.IsInt())
            {
                var v = md.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                var child = csd.GetByCName(sysname);
                if (Service.EmailService.SendActiveEmail(cid.ToInt().Value, child.Domain, cdb, sysname ))
                {
                    v.IsMailSend = 1;
                    var db = new DBRepository<Member>(cdb);

                    if (db.Update(v, true))
                    {
                        return Json(Success(ToJson(new
                        {
                            Msg = ""
                        })));
                    }
                    else
                    {
                        return Json(Fail("修改失败"));
                    }
                }
                else
                {
                    return Json(Fail("发送失败"));
                }
            }
            else
            {
                return Json(Fail("参数id不正确"));
            }
        }




        /// <summary>
        /// 激活账户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AdminPower]
        public IActionResult ActiveUserSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            md.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = md.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                v.IsRegist = 1;
                var db = new DBRepository<Member>(cdb);
                if (db.Update(v, true))
                {
                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
                else
                {
                    return Json(Fail("激活失败"));
                }
            }
            else
            {
                return Json(Fail("参数id不正确"));
            }
        }
        #endregion



        #region 支付信息
        [AdminPower]
        public IActionResult PayList()
        {
            int pagesize = 30;
            int? pageindex = Project.ReqPara("pageindex").ToInt();
            int? pagenum = Project.ReqPara("pagenum").ToInt();
            if (pagenum != null)
            {
                pageindex = pagenum;
            }
            else
            {
                pageindex = pageindex == null ? 1 : pageindex.Value;
            }

            var cdb = GetViewDb();
            var Email = ReqPara("Email");
            var State = ReqPara("State");
            var starttime = ReqPara("starttime");
            var endtime = ReqPara("endtime");


            var dbq = new DBRepository<Payorder>(cdb).DbQuery;
            if (!Email.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.Member.Email.Contains(Email));
            }
            if (State.IsInt())
            {
                var v = State.ToInt().Value;
                dbq = dbq.Where(p => p.State == v);
            }
            if (!starttime.IsNullOrEmpty())
            {
                var starttime1 = starttime.Replace("-", "");
                var v = new DateTime(starttime1.Substring(0, 4).ToInt().Value, starttime1.Substring(4, 2).ToInt().Value, starttime1.Substring(6, 2).ToInt().Value);
                dbq = dbq.Where(p => p.CreateTime >= v);
            }
            if (!endtime.IsNullOrEmpty())
            {
                var endtime1 = endtime.Replace("-", "");
                var v = new DateTime(endtime1.Substring(0, 4).ToInt().Value, endtime1.Substring(4, 2).ToInt().Value, endtime1.Substring(6, 2).ToInt().Value, 23, 59, 59);
                dbq = dbq.Where(p => p.CreateTime <= v);
            }


            var lst = dbq.OrderByDescending(p => p.CreateTime).Skip((pageindex.Value - 1) * pagesize).Take(pagesize).Select(p => new
            {
                p.Member.Email,
                p.Money,
                p.PayWay,
                p.State,
                p.CreateTime,
                p.Payordermemberserviceref
            }).Distinct().ToList().Select(p => new
            {
                p.Email,
                Money = p.Money / 100.0,
                p.PayWay,
                p.State,
                CreateTime = p.CreateTime.ToString("yyyy-MM-dd"),
                starttime = (p.Payordermemberserviceref == null || p.Payordermemberserviceref.FirstOrDefault() == null) ? "-" : p.Payordermemberserviceref.FirstOrDefault().StartTime.ToString("yyyy-MM-dd"),
                endtime = (p.Payordermemberserviceref == null || p.Payordermemberserviceref.FirstOrDefault() == null) ? "-" : p.Payordermemberserviceref.FirstOrDefault().EndTime.ToString("yyyy-MM-dd")
            }).ToList();
            ViewBag.pageindex = pageindex;
            ViewBag.pagesize = pagesize;
            ViewBag.Count = dbq.Count();
            ViewBag.List = lst;
            ViewBag.State = State;
            ViewBag.starttime = starttime;
            ViewBag.endtime = endtime;
            ViewBag.Email = Email;
            return View();
        }

        #endregion



        #region 兑换码
        [AdminPower]
        public IActionResult PayCodeList()
        {
            var cdb = GetViewDb();
            var Code = ReqPara("Code");
            var IsUse = ReqPara("IsUse");
            if (IsUse.IsNullOrEmpty())
            {
                IsUse = "0";
            }
            int pagesize = 30;
            int? pageindex = Project.ReqPara("pageindex").ToInt();
            int? pagenum = Project.ReqPara("pagenum").ToInt();
            if (pagenum != null)
            {
                pageindex = pagenum;
            }
            else
            {
                pageindex = pageindex == null ? 1 : pageindex.Value;
            }


            var dbq = new DBRepository<Preferentialcode>(cdb).DbQuery.Where(p=>p.IsDelete==0);
            if (!Code.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.Code== Code);
            }
            if (IsUse == "1")
            {
                dbq = dbq.Where(p => p.IsUse == 1);
            }
            else
            {
                dbq = dbq.Where(p => p.IsUse == 0);
            }
            var lst = dbq.OrderByDescending(p => p.CreateTime).Skip((pageindex.Value - 1) * pagesize).Take(pagesize).Distinct().Distinct().ToList();
            ViewBag.pageindex = pageindex;
            ViewBag.pagesize = pagesize;
            ViewBag.Count = dbq.Count();
            ViewBag.List = lst;
            ViewBag.IsUse = IsUse;
            ViewBag.Code = Code;

            return View();
        }


        [AdminPower]
        public IActionResult PayCodeDetail()
        {
            var cid = ReqPara("cid");

            var cdb = GetViewDb();
            pcd.dbcontext = cdb;
            pd.dbcontext = cdb;
            md.dbcontext = cdb;
            ViewBag.plst= pd.GetAllInUseProduct();
            Preferentialcode v = null;

            if (cid.IsInt())
            {
                v = pcd.GetById(cid.ToInt().Value);
                if (v != null)
                {
                    ViewBag.cid = v.Id;
                    ViewBag.Code = v.Code;
                    ViewBag.CreateTime = v.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    ViewBag.IsUse = v.IsUse == (short)1 ? "已使用" : "未使用";
                    ViewBag.IsRegist = v.IsDelete == (short)1 ? "，已删除" : "，未删除";
                    if(v.MemberId!=null)
                    {
                        var m = md.GetById(v.MemberId.Value);
                        if(m!=null)
                        {
                            ViewBag.Member = "，使用人："+m.Email;
                        } 
                    }
                    if (v.UseTime != null)
                    {
                        ViewBag.UseTime = "，使用时间：" + v.UseTime.Value.ToStr();
                    }
                    
                    var prlst = pcd.GetPcRef(v.Id);
                    if(prlst!=null&&prlst.Count>0)
                    {
                        ViewBag.ProId = prlst[0].ProId;
                    }
                }
            }
             
            return View();
        }

        [HttpPost]
        [AdminPower]
        public IActionResult PayCodeDeleteSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            pcd.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = pcd.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                v.IsDelete = 1;
                var db = new DBRepository<Preferentialcode>(cdb);
                if (db.Update(v, true))
                {
                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
                else
                {
                    return Json(Fail("删除失败"));
                }
            }
            else
            {
                return Json(Fail("参数id不正确"));
            }
        }

        [HttpPost]
        [AdminPower]
        public IActionResult PayCodeDetailSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            var proid = ReqPara("Product");
            if(!proid.IsInt())
            {
                return Json(Fail("请选择一个套餐"));
            }
            pcd.dbcontext = cdb;
            Preferentialcode v = null;
            if (cid.IsInt())
            {
                 v = pcd.GetById(cid.ToInt().Value); 
            }
            if (v == null)
            {
                v = new Preferentialcode()
                {
                    Code = Guid.NewGuid().ToString().Replace("-", ""),
                    IsDelete = 0,
                    IsUse = 0,
                    CreateTime = DateTime.Now 
                };
              
                var db = new DBRepository<Preferentialcode>(cdb);
                if (db.Add(v, true))
                {
                    v= pcd.GetNewPC();
                    var pr = new Preferentialcoderef()
                    {
                        CreateTime = DateTime.Now,
                        ProId = proid.ToInt().Value,
                         PreferentialCodeId=v.Id
                    }; 
                    var dbpr = new DBRepository<Preferentialcoderef>(cdb);
                    if (dbpr.Add(pr, true))
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
                else
                {
                    return Json(Fail("保存失败"));
                }
            }
            else
            {
                var prlst = pcd.GetPcRef(v.Id);
                prlst[0].ProId = proid.ToInt().Value;
                var db = new DBRepository<Preferentialcoderef>(cdb);
                if (db.Update(prlst[0], true))
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
        
        }
        #endregion
    }
}
