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

namespace AdminWeb.Controllers
{
    public class WorkOrderController : BaseController
    {
        WorkOrderDAL wod = new WorkOrderDAL();
        MemberDAL md = new MemberDAL();

        [AdminPower]
        public IActionResult List()
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
            var Content = ReqPara("Content");
            var State = ReqPara("State");
            if(!State.IsInt())
            {
                State = "1";
            }

            var dbq = new DBRepository<Workorder>(cdb).DbQuery;
            if (!Content.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.Content.Contains(Content));
            }
            if (State == "1")
            {
                dbq = dbq.Where(p => p.State == 1);
            }
            else
            {
                dbq = dbq.Where(p => p.State == 9);
            }
            var count = dbq.Distinct().Count();
            var lst = dbq.OrderBy(p => p.CreateTime).Skip((pageindex.Value - 1) * pagesize).Take(pagesize).Select(p=>new { 
                p.Id,
                p.CreateTime,
                p.Member.Email,
                p.Content,
                p.State
                
            }).Distinct().ToList();

            ViewBag.lst = lst;
            ViewBag.Content = Content;
            ViewBag.State = State;
            ViewBag.Count = count;
            ViewBag.pageindex = pageindex;
            ViewBag.pagesize = pagesize;
            return View();
        }


        [AdminPower]
        public IActionResult Detail()
        {
            var cid = ReqPara("cid");

            var cdb = GetViewDb();
            wod.dbcontext = cdb;
            md.dbcontext = cdb;

            Workorder v = null;
            List<Workorderdetail> wd = null;
            if (cid.IsInt())
            {
                v = wod.GetById(cid.ToInt().Value);
                if (v != null)
                {
                    ViewBag.cid = v.Id;
                    var m = md.GetById(v.MemberId); 
                    ViewBag.Email = m.Email;
                    ViewBag.CreateTime = v.CreateTime.ToStr();
                    ViewBag.Content = v.Content;
                    ViewBag.State = v.State; 
                    wd = wod.GetDetailsByWoId(v.Id);
                    ViewBag.wd = wd;
                }
            } 
            return View();
        }


        [HttpPost]
        [AdminPower]
        public IActionResult CloseOrderSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            wod.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = wod.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                var db = new DBRepository<Workorder>(cdb);
                v.State = 9;
                if (db.Update(v, true))
                {
                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
                else
                {
                    return Json(Fail("关闭失败"));
                }
            }
            else
            {
                return Json(Fail("参数id不正确"));
            }



        }



        [HttpPost]
        [AdminPower]
        public IActionResult ReplySubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            var ReplyContent = ReqPara("ReplyContent");
            if(ReplyContent.IsNullOrEmpty())
            {
                return Json(Fail("请输入回复内容"));
            }
            wod.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = wod.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                var db = new DBRepository<Workorderdetail>(cdb);
                var wd = new Workorderdetail() { 
                 WodType=2,
                  Content= ReplyContent,
                   CreateTime=DateTime.Now,
                    Woid=v.Id
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
    }
}
