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
    public class PackageController : BaseController
    {
        ProductDAL pd=new ProductDAL();
        SystemBaseDAL sbd = new SystemBaseDAL();

        [AdminPower]
        public IActionResult List()
        {
            var cdb = GetViewDb();
            var ProName = ReqPara("ProName"); 
            var isuse = ReqPara("isuse"); 
            if (isuse.IsNullOrEmpty())
            {
                isuse = "1";
            }
            var dbq = new DBRepository<Product>(cdb).DbQuery;
            if (!ProName.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.ProName.Contains(ProName)); 
            } 
            if (isuse == "1")
            {
                dbq = dbq.Where(p => p.IsUse == 1);
            }
            else
            {
                dbq = dbq.Where(p => p.IsUse == 0);
            }
            var lst = dbq.OrderBy(p => p.CreateTime).Distinct().ToList();

            ViewBag.List = lst;
            ViewBag.isuse = isuse;
            ViewBag.ProName = ProName;
            return View();
        }


        [AdminPower]
        public IActionResult Detail()
        {
            var cid = ReqPara("cid");

            var cdb = GetViewDb();
            pd.dbcontext = cdb;
            sbd.dbcontext = cdb;
            var vdbq = new DBRepository<Vpnserver>(cdb).DbQuery;
            var vlst = vdbq.Where(p => p.IsUse == 1).OrderBy(p => p.Weight).ToList();
            ViewBag.vlst = vlst;


            Product v = null;
           
            if ( cid.IsInt())
            {
                v = pd.GetById(cid.ToInt().Value);
                if (v != null)
                {
                    ViewBag.cid = v.Id;
                    ViewBag.ProName = v.ProName;
                    ViewBag.DurationDate = v.DurationDate;
                    ViewBag.IsUse = v.IsUse;
                    ViewBag.Traffic = v.Traffic/(1024*1024*1024);
                    ViewBag.Price = v.Price/100.0;
                    ViewBag.Description = v.Description;
                    ViewBag.MaxOnlineUser = v.MaxOnlineUser;
                    ViewBag.FlushTrafficDate = v.FlushTrafficDate;
                    var pvlst = pd.GetServerRef(v.Id);
                    if(pvlst!=null)
                    {
                        ViewBag.pvlst = pvlst.Select(p => p.Vpnid).ToList();
                    }
                }
            }
            if(v==null)
            {
                ViewBag.IsUse = (short)1;
                ViewBag.FlushTrafficDate = 31;
                ViewBag.MaxOnlineUser = sbd.GetMaxOnLineUser();
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

            var ProName = ReqPara("ProName");
            var DurationDate = ReqPara("DurationDate");
            var Traffic = ReqPara("Traffic");
            var IsUse = ReqPara("IsUse");
            var Price = ReqPara("Price");
            var Description = ReqPara("Description");
            var MaxOnlineUser = ReqPara("MaxOnlineUser");
            var FlushTrafficDate = ReqPara("FlushTrafficDate");


            if (ProName.IsNullOrEmpty())
            {
                return Json(Fail("请输入套餐名"));
            }
            if (!DurationDate.IsInt())
            {
                return Json(Fail("套餐时间请输入整数"));
            }
            if (!Traffic.IsFloat())
            {
                return Json(Fail("周期流量请输入数字"));
            }
            if (!Price.IsFloat())
            {
                return Json(Fail("价格请输入数字"));
            }
            if (!MaxOnlineUser.IsInt())
            {
                return Json(Fail("最大在线人数请输入数字"));
            }
            if (!FlushTrafficDate.IsInt())
            {
                return Json(Fail("流量刷新间隔天数请输入数字"));
            }

            List<int> cklst = new List<int>();
            foreach(var key in Request.Form.Keys)
            {
                if(key.StartsWith("ck_")&& !Request.Form[key].ToString().IsNullOrEmpty())
                {
                    cklst.Add(key.Replace("ck_", "").ToInt().Value);
                }
            }

            if (cdb != null)
            {
                pd.dbcontext = cdb;
              
                Product vg = null;
                if (cid.IsInt())
                {
                    vg = pd.GetById(cid.ToInt().Value);
                }
                var db = new DBRepository<Product>(cdb);
                var dbpvr = new DBRepository<Provpnref>(cdb);
                if (vg == null)
                {
                    //new
                    vg = new Product()
                    {
                        CreateTime = DateTime.Now,
                        IsUse = IsUse == "1" ? (short)1 : (short)0,
                        Description = Description,
                        DurationDate = DurationDate.ToInt().Value,
                        FlushTrafficDate = FlushTrafficDate.ToInt().Value,
                        MaxOnlineUser = MaxOnlineUser.ToInt().Value,
                        Price = Convert.ToInt32(Price.ToFloat().Value * 100),
                        ProName = ProName,
                        Traffic = Convert.ToInt64(Traffic.ToFloat().Value * 1024 * 1024 * 1024)
                    };
                    if(db.Add(vg,true))
                    {
                        var np = pd.GetNewestProduct(); 
                        pd.AddProServerRef(cklst, np.Id, false);
                    }
                }
                else
                {
                    //update

                    vg.IsUse = IsUse == "1" ? (short)1 : (short)0;
                    vg.Description = Description;
                    vg.DurationDate = DurationDate.ToInt().Value;
                    vg.FlushTrafficDate = FlushTrafficDate.ToInt().Value;
                    vg.MaxOnlineUser = MaxOnlineUser.ToInt().Value;
                    vg.Price = Convert.ToInt32(Price.ToFloat().Value * 100);
                    vg.ProName = ProName;
                    vg.Traffic = Convert.ToInt64(Traffic.ToFloat().Value * 1024 * 1024 * 1024);
                    db.Update(vg); 
                    pd.AddProServerRef(cklst, vg.Id, false); 
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
            pd.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = pd.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                var db = new DBRepository<Product>(cdb);
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
            pd.dbcontext = cdb;
            if (cid.IsInt())
            {
                var v = pd.GetById(cid.ToInt().Value);
                if (v == null)
                {
                    return Json(Fail("数据不存在"));
                }
                v.IsUse = v.IsUse == (short)1 ? (short)0 : (short)1;
                var db = new DBRepository<Product>(cdb);
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
