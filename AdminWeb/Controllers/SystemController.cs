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
    public class SystemController : BaseController
    {
        SystemBaseDAL sbd = new SystemBaseDAL();
        public SystemController()
        {
            csd.dbcontext = admindbcontext;

        }

        #region 子系统
        [AdminPower]
        public IActionResult ChildSystemList()
        {
            var lst = csd.GetAll();
            ViewBag.syslst = lst;
            return View();
        }


        [AdminPower]
        public IActionResult ChildSystemDetail()
        {
            var id = ReqPara("cid");
            if (id.IsInt())
            {
                var c = csd.GetById(id.ToInt().Value);
                if (c != null)
                {
                    ViewBag.cid = id;
                    ViewBag.Cname = c.Cname;
                    ViewBag.Domain = c.Domain;
                    ViewBag.SqlurlSs = c.SqlurlSs;
                    ViewBag.SqlurlWeb = c.SqlurlWeb;
                }
            }
            return View();
        }

        [HttpPost]
        [AdminPower]
        public IActionResult ChildSystemDetailSubmit()
        {
            string Cname = ReqPara("Cname");
            string id = ReqPara("cid");
            string Domain = ReqPara("Domain");
            string SqlurlWeb = ReqPara("SqlurlWeb");
            string SqlurlSs = ReqPara("SqlurlSs");
            if (Cname.IsNullOrEmpty())
            {
                return Json(Fail("系统名不能为空"));
            }
            if (Domain.IsNullOrEmpty())
            {
                return Json(Fail("域名不能为空"));
            }
            if (SqlurlWeb.IsNullOrEmpty())
            {
                return Json(Fail("网站数据库链接不能为空"));
            }
            if (SqlurlSs.IsNullOrEmpty())
            {
                return Json(Fail("SS数据库链接不能为空"));
            }
            Childsystem c = null;
            if (id.IsInt())
            {
                c = csd.GetById(id.ToInt().Value);
            }
            var dbc = new DBRepository<Childsystem>(admindbcontext);

            if (c == null)
            {
                c = new Childsystem()
                {
                    SqlurlSs = SqlurlSs,
                    Cname = Cname,
                    Domain = Domain,
                    SqlurlWeb = SqlurlWeb
                };
                if (dbc.Add(c, true))
                {

                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
                else
                {
                    return Json(Fail("保存到数据库失败"));
                }
            }
            else
            {
                c.SqlurlSs = SqlurlSs;
                c.Cname = Cname;
                c.Domain = Domain;
                c.SqlurlWeb = SqlurlWeb;
                if (dbc.Update(c, true))
                {

                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
                else
                {
                    return Json(Fail("保存到数据库失败"));
                }
            }

        }
        #endregion


        #region 基础设置

        [AdminPower]
        public IActionResult SystemBase()
        {
            var syslst = csd.GetAll();
            var sysname = ReqPara("syslst");
            Childsystem cs = null;
            if (!sysname.IsNullOrEmpty())
            {
                cs = csd.GetByCName(sysname);
            }
            if (cs == null)
            {
                cs = syslst[0];
                sysname = cs.Cname.ToString();
            }

            ViewBag.syslst = syslst;
            ViewBag.sysname = sysname;

            var cdb = GetCdbByCName(sysname);
            if (cdb != null)
            {
                sbd.dbcontext = cdb;
                var kvlst = sbd.GetAll();
                ViewBag.kvlst = kvlst;
            }
            return View();
        }



        [HttpPost]
        [AdminPower]
        public IActionResult SystemBaseSubmit()
        {
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            List<Systembase> lst = new List<Systembase>();
            sbd.dbcontext = cdb;
            foreach (var key in Request.Form.Keys)
            {
                if (key.IndexOf("si_") == 0)
                {
                    lst.Add(new Systembase() { Key = key.Replace("si_", ""), Value = Request.Form[key] });
                }
            }
            if (lst.Count > 0)
            { 
                if (sbd.Update(lst))
                {
                    return Json(Success(ToJson(new
                    {
                        Msg = ""
                    })));
                }
            }
            return Json(Fail("保存到数据库失败"));
        }
        #endregion
    }
}
