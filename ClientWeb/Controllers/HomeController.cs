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
    public class HomeController : BaseController
    {
        ProductDAL pd = new ProductDAL();

        public IActionResult Index()
        {
            return Redirect("/User/Login"); 

            
            var temppath = AppContext.BaseDirectory + "template/html/home/index.html";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

        public IActionResult Price()
        {
            return Redirect("/User/Login");


            var temppath = AppContext.BaseDirectory + "template/html/home/price.html";
            var html = Common.MyFile.GetFileString(temppath);
            ViewBag.html = RenderPage(html);
            return View();
        }

        public IActionResult GetProductById()
        {
            var id = ReqPara("id");
            if(!id.IsInt())
            {
                return Json(Fail(""));
            }
            pd.dbcontext = dbcontextWeb;
            var p = pd.GetById(id.ToInt().Value);
            if(p==null)
            {
                return Json(Fail(""));
            }
            else
            {
                return Json(Success(ToJson(new { p.Id, ProName = p.ProName,Price=p.Price/100.0, Month = (p.DurationDate / 31), Traffic=p.Traffic/(1024*1024*1024), MaxOnlineUser=p.MaxOnlineUser })));
            } 
        }

        public IActionResult GetAllProduct()
        { 
            pd.dbcontext = dbcontextWeb;
            var lst = pd.GetAllInUseProduct().Select(p => new {p.Id, p.ProName, Price = p.Price / 100.0, Month = p.DurationDate / 31, Traffic = p.Traffic / (1024 * 1024 * 1024), MaxOnlineUser = p.MaxOnlineUser }).ToList();
            return Json(Success(ToJson(lst)));
        }
 
     }
}
