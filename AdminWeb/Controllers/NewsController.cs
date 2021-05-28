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
    public class NewsController : BaseController
    {
        SystemBaseDAL sbd = new SystemBaseDAL();
        NewsDAL nd = new NewsDAL();


        [AdminPower]
        public IActionResult  List()
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
            var key = ReqPara("key");
         
            var isuse = ReqPara("isuse");
          
            if (isuse.IsNullOrEmpty())
            {
                isuse = "1";
            }

            var dbq = new DBRepository<News>(cdb).DbQuery;
            if (!key.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.Title.Contains(key));

            } 
            if (isuse == "1")
            {
                dbq = dbq.Where(p => p.IsUse == 1);
            }
            else
            {
                dbq = dbq.Where(p => p.IsUse == 0);
            }
           
            var count = dbq.Distinct().Count();
            var lst = dbq.OrderByDescending(p => p.CreateTime).Skip((pageindex.Value - 1) * pagesize).Take(pagesize).Distinct().ToList();

            ViewBag.pageindex = pageindex.Value;
            ViewBag.pagesize = pagesize;
            ViewBag.Count = count;
            ViewBag.List = lst;
            ViewBag.isuse = isuse;
            ViewBag.key = key; 
            ViewBag.clst = Project.GetAllCountry();


            return View();
        }


        [AdminPower]
        public IActionResult  Detail()
        {

            var cid = ReqPara("cid"); 
            var cdb = GetViewDb();
            nd.dbcontext = cdb;
         
            News v = null;
            if (cid.IsInt())
            {
                v = nd.GetById(cid.ToInt().Value);
                if (v != null)
                {
                    ViewBag.cid = v.Id;
                    ViewBag.Title = v.Title;
                    ViewBag.Content = v.Content; 
                }
            }
             
            return View();
        }

        [HttpPost]
        [AdminPower]
        public IActionResult DetailSubmit()
        {
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            var cid = ReqPara("cid");

            var Title = ReqPara("Title");
            var Content = ReqPara("Content"); 


            if (Title.IsNullOrEmpty())
            {
                return Json(Fail("请输入标题"));
            }
            if (Content.IsNullOrEmpty())
            {
                return Json(Fail("请输入内容"));
            }


            var db = new DBRepository<News>(cdb);
            if (cdb != null)
            {
                nd.dbcontext = cdb;

                News n = null;
                if (cid.IsInt())
                {
                    n = nd.GetById(cid.ToInt().Value);
                }
             
                if (n == null)
                {
                    //new
                    n = new News()
                    {
                        CreateTime = DateTime.Now,
                        IsUse = (short)1  ,
                        Content = Content,
                        Title = Title,
                    };
                    db.Add(n);
                }
                else
                {
                    //update

                   
                    n.Content = Content;
                    n.Title = Title;
                  
                    db.Update(n);
                   
                }
                try
                {
                    cdb.SaveChanges();
                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
                catch
                {
                    return Json(Fail("保存到数据库失败"));
                }
            }


            return Json(Fail("数据库不存在"));
        }

        [HttpPost]
        [AdminPower]
        public IActionResult DeleteSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            nd.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = nd.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                var db = new DBRepository<News>(cdb);
                if (db.Delete(v, true))
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
        public IActionResult ChangeSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            nd.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = nd.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                v.IsUse = v.IsUse == (short)1 ? (short)0 : (short)1;
                var db = new DBRepository<News>(cdb);
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
    }
}
