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
    public class VpnServerController : BaseController
    {
      
        VPNServerDAL vsd = new VPNServerDAL();

        


        #region 服务器
      
        [AdminPower]
        public IActionResult ServerList()
        {
            int pagesize =30;
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
            var ServerName = ReqPara("ServerName");
            var country = ReqPara("country");
            var isuse = ReqPara("isuse");
            var ProxyType = ReqPara("ProxyType");
            if (isuse.IsNullOrEmpty())
            {
                isuse = "1";
            }

            var dbq = new DBRepository<Vpnserver>(cdb).DbQuery;
            if(!ServerName.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.ServerName.Contains(ServerName));
               
            }
            if(!country.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.Country==country);
            }
            if(isuse=="1")
            {
                dbq = dbq.Where(p => p.IsUse == 1);
            }
            else
            {
                dbq = dbq.Where(p => p.IsUse == 0);
            }
            if(!ProxyType.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.ProxyType == ProxyType);
            }
            var count = dbq.Distinct().Count();
            var lst = dbq.OrderBy(p => p.Weight).Skip((pageindex.Value - 1) * pagesize).Take(pagesize).Distinct().ToList();

            ViewBag.pageindex = pageindex.Value;
            ViewBag.pagesize = pagesize;
            ViewBag.Count = count;
            ViewBag.List = lst;
            ViewBag.isuse = isuse;
            ViewBag.country = country;
            ViewBag.ServerName = ServerName;
            ViewBag.clst = Project.GetAllCountry();


            return View();
        }

     
        [AdminPower]
        public IActionResult ServerDetail()
        {

            var cid = ReqPara("cid");

            var cdb = GetViewDb();
            vsd.dbcontext = cdb;
            
            var clst = Project.GetAllCountry();
            ViewBag.clst = clst;
         
            Vpnserver v = null;
            if (cid.IsInt())
            {
                  v = vsd.GetById(cid.ToInt().Value);
                if (v != null)
                {
                    ViewBag.cid = v.Id;
                    ViewBag.ServerName = v.ServerName;
                    ViewBag.Country = v.Country;
                    ViewBag.IsUse = v.IsUse;
                 
                    ViewBag.Port = v.Port;
                    ViewBag.Passwd = v.Passwd;
                    ViewBag.Method = v.Method;
                    ViewBag.Obfs = v.Obfs;
                    ViewBag.Protocol = v.Protocol;
                    ViewBag.ProxyType = v.ProxyType; 
                    ViewBag.Domain = v.Domain;
                    ViewBag.Weight = v.Weight; 
                } 
            }
            if(v==null)
            {
                var dbq = new DBRepository<Vpnserver>(cdb).DbQuery;
                var newV = dbq.Where(p => p.IsUse == 1).OrderByDescending(P => P.CreateTime).FirstOrDefault();
                if (newV != null)
                {
                    ViewBag.Country = newV.Country;
                    ViewBag.IsUse = newV.IsUse;
                
                    ViewBag.Port = newV.Port;
                    ViewBag.Passwd = newV.Passwd;
                    ViewBag.Method = newV.Method;
                    ViewBag.Obfs = newV.Obfs;
                    ViewBag.Protocol = newV.Protocol;
                    ViewBag.ProxyType = newV.ProxyType;
                    ViewBag.Domain = newV.Domain;
                    ViewBag.Weight = newV.Weight + 1;
                }
            }    
            return View();
        }

        [HttpPost]
        [AdminPower]
        public IActionResult ServerDetailSubmit()
        {

            var cdb = GetViewDb();
            var ServerName = ReqPara("ServerName");
            var Port = ReqPara("Port");
            var Weight = ReqPara("Weight");
            var Domain = ReqPara("Domain");
            var Passwd = ReqPara("Passwd"); 
            var ProxyType = ReqPara("ProxyType");
            var Method = ReqPara("Method");
            var Obfs = ReqPara("Obfs");
            var Protocol = ReqPara("Protocol");
         
            var country = ReqPara("country"); 
            var IsUse= ReqPara("IsUse");
            var cid = ReqPara("cid");
            if (ServerName.IsNullOrEmpty())
            {
                return Json(Fail("请填写服务器名"));
            }
            if (Port.IsNullOrEmpty())
            {
                return Json(Fail("请填写端口号"));
            }
            if (Weight.IsNullOrEmpty()|| !Weight.IsFloat())
            {
                return Json(Fail("权重必须填写，且必须为数字"));
            }
            if (Passwd.IsNullOrEmpty())
            {
                return Json(Fail("请填写密码"));
            }


            if (cdb != null)
            {
                
                vsd.dbcontext = cdb;
                Vpnserver v = null;
                if (cid.IsInt())
                {
                    v = vsd.GetById(cid.ToInt().Value);
                }
                var db = new DBRepository<Vpnserver>(cdb);
                if (v == null)
                {
                    //new
                    v = new Vpnserver()
                    {
                        CreateTime = DateTime.Now,
                        Port = Port,
                        Country = country,
                        Domain = Domain,
                        IsUse = IsUse == "1" ? (short)1 : (short)0,
                        Method = Method,
                        Obfs = Obfs,
                        Passwd = Passwd,
                        Protocol = Protocol,
                        ProxyType = ProxyType,
                        ServerName = ServerName,
                     
                        Weight = Weight.ToFloat().Value
                    };
                    db.Add(v);
                }
                else
                {
                    //update

                    v.Port = Port;
                    v.Country = country;
                    v.Domain = Domain;
                    v.IsUse = IsUse == "1" ? (short)1 : (short)0;
                    v.Method = Method;
                    v.Obfs = Obfs;
                    v.Passwd = Passwd;
                    v.Protocol = Protocol;
                    v.ProxyType = ProxyType;
                    v.ServerName = ServerName;
                 
                    v.Weight = Weight.ToFloat().Value;
                    db.Update(v);
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


            return View();
        }


        [HttpPost]
        [AdminPower]
        public IActionResult DeleteServerSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            vsd.dbcontext = cdb;
            if(cid.IsInt())
            {
                var v = vsd.GetById(cid.ToInt().Value);
                if(v==null)
                {
                    return Json(Fail("数据不存在"));
                }
                var db = new DBRepository<Vpnserver>(cdb);
                if(db.Delete(v,true))
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
        public IActionResult ChangeServerSubmit()
        {
            var cid = ReqPara("cid");
            var sysname = ReqPara("syslst");
            var cdb = GetCdbByCName(sysname);
            vsd.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = vsd.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                v.IsUse = v.IsUse == (short)1 ? (short)0 : (short)1;
                var db = new DBRepository<Vpnserver>(cdb);
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
        #endregion
    }
}
