using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AdminWeb.core;
using Common.Web;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model;
using Model.admin;
using Model.client;

namespace AdminWeb.Core
{
    public class BaseController : Controller
    {
        public int pagesize = 10;
        public stadminContext admindbcontext = null;
        public List<KeyValuePair<String, stclientContext>> clientdbcontext = null;
        public Admininfo user = null;
        string mysqlAdminUrl = "Server=127.0.0.1;Port=3306;Database=sspadmin;User=root;Password=superme1993;Character Set=utf8;";

        public stclientContext GetCdbByCName(string cname)
        {
           var db= clientdbcontext.Where(p => p.Key == cname).FirstOrDefault().Value;
            return db;
        }

        #region DAL

       public  ChildSystemDAL csd = new ChildSystemDAL();
        public AdminInfoDAL aid = new AdminInfoDAL();
        #endregion



        public stclientContext GetViewDb()
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
            return cdb;
        }


        public BaseController()
        {

          
            admindbcontext = new stadminContext(mysqlAdminUrl);
            csd.dbcontext = admindbcontext;
            aid.dbcontext = admindbcontext;
            ReloadChildContext();
             
        }

        /// <summary>
        /// 从数据库中读取配置文件数据
        /// </summary>
        private void ReloadChildContext()
        {
            var childsytemlst = csd.GetAll();
            if (childsytemlst != null && childsytemlst.Count > 0)
            {
                clientdbcontext = new List<KeyValuePair<string, stclientContext>>();
                foreach (var cs in childsytemlst)
                {
                    clientdbcontext.Add(new KeyValuePair<string, stclientContext>(cs.Cname, new stclientContext(cs.SqlurlWeb)));
                }
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            

            if (Passport.GetPassport(Project.LoginKey) != null)
            {
                user = Passport.GetPassport(Project.LoginKey) as Admininfo;

            }
            base.OnActionExecuting(filterContext);
        }

        public string ReqPara(string key)
        {
            string val = null;
            if (Request.HasFormContentType && Request.Form.ContainsKey(key))
            {
                val = Request.Form[key];
            }
            else if (Request.Query.ContainsKey(key))
            {
                val = Request.Query[key];
            }
            val = System.Net.WebUtility.UrlDecode(val);//获取提交过来的数据，并解码
            val = Common.Web.InjectionAttack.MyEncodeInputString(val);//对关键字符进行过滤
            return val;
        }

        #region Admin用户权限的Attribute
        /// <summary>
        /// Action执行前/后的Attribute
        /// </summary>
        public class AdminPowerAttribute : ActionFilterAttribute
        {
            private string errorMsg = "";


            Common.Str.DESEncrypt des = new Common.Str.DESEncrypt();

            //action执行之前先执行此方法  
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (Passport.GetPassport(Project.LoginKey) == null)
                {
                    errorMsg = "请重新登录";
                    filterContext.Result = new RedirectResult("/Home/Login?msg=" + errorMsg);
                }
 
                base.OnActionExecuting(filterContext);
            }

            //action执行之后先执行此方法  
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);

                //HttpContext.Current.Response.Write("<br />onActionExecuted:" + Name);
            }
            //actionresult执行之前执行此方法  
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                base.OnResultExecuting(filterContext);
                //HttpContext.Current.Response.Write("<br />OnResultExecuting:" + Name);

            }

            //actionresult执行之后执行此方法  
            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                base.OnResultExecuted(filterContext);
                //HttpContext.Current.Response.Write("<br />OnResultExecuted:" + Name);

            }
        }


        #endregion
        

        #region 提交
        /// <summary>
        /// 单独提交
        /// </summary>
        /// <param name="dbc"></param>
        /// <returns></returns>
        public bool Submit(DbContext dbc)
        {
            if (dbc == null) return false;
            return Project.Submit(dbc);
        }

        /// <summary>
        /// 群体提交
        /// </summary>
        /// <returns></returns>
        public bool Submit()
        {
            try
            {
                if (admindbcontext != null)
                {
                    admindbcontext.SaveChanges();
                }
                if (clientdbcontext != null)
                {
                    foreach (var cdb in clientdbcontext)
                    {
                        cdb.Value.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 转换成json格式
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string ToJson(object o)
        {
            return Common.Json.ClassJson.ClassToJson(o);
        }


        /// <summary>
        /// 成功的值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object Success(string msg)
        {
            return new { rt = true, msg = msg };
        }

        /// <summary>
        /// 失败的值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object Fail(string msg)
        {
            return new { rt = false, msg = msg };
        }

        #region 分部视图
        /// <summary>
        /// 通用HEADER
        /// </summary>
        /// <returns></returns>
        public ActionResult _Head(string active)
        {
            ViewBag.Active = active;
            return PartialView("_Head");
        }


        /// <summary>
        /// 通用Top
        /// </summary>
        /// <returns></returns>
        public ActionResult _Top(string active)
        {
            ViewBag.Active = active;
            return PartialView("_Top");
        }

        /// <summary>
        /// 通用Foot
        /// </summary>
        /// <returns></returns>
        public ActionResult _Foot(string active)
        {
            ViewBag.Active = active;
            return PartialView("_Foot");
        }

        #endregion
    }
}
