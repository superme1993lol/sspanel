using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.DrawingCore.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClientWeb.Core;
using Common.Web;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model;
using Model.admin;
using Model.client;
using Model.ssr;

namespace ClientWeb.Core
{
    public class BaseController : Controller
    {


        public int pagesize = 10;
        public stclientContext dbcontextWeb = null;
        public stssrContext dbcontextSs = null;


        public Member user = null;

        public Common.Str.DESEncrypt des = new Common.Str.DESEncrypt();


        public BaseController()
        {
            if (Program.sqlurlWeb.IsNullOrEmpty())
            {
                //从本地配置文件读取数据库链接
                Program.LoadConfig();
            }
            dbcontextWeb = new stclientContext(Program.sqlurlWeb);
            dbcontextSs = new stssrContext(Program.sqlurlSS);
            if (Passport.GetPassport(Project.LoginKey) != null)
            {
                user = Passport.GetPassport(Project.LoginKey) as Member;
            }
        }



        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            if (Passport.GetPassport(Project.LoginKey) != null)
            {
                user = Passport.GetPassport(Project.LoginKey) as Member;

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

        #region Member用户权限的Attribute
        /// <summary>
        /// Action执行前/后的Attribute
        /// </summary>
        public class MemberPowerAttribute : ActionFilterAttribute
        {
            private string errorMsg = "";


            Common.Str.DESEncrypt des = new Common.Str.DESEncrypt();

            //action执行之前先执行此方法  
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (Passport.GetPassport(Project.LoginKey) == null)
                {
                    errorMsg = "请重新登录";
                    filterContext.Result = new RedirectResult("/User/Login?msg=" + errorMsg);
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
                if (dbcontextWeb != null)
                {
                    dbcontextWeb.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 返回信息
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
        #endregion

         
        /// <summary>
        /// 渲染页面
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public string RenderPage(string html,List<KeyValuePair<string,string>> selfkv=null)
        {
            #region 公用页面替换
            var sp = Program.sharepage;
            foreach (var s in sp)
            {
                html = html.Replace("{" + s.Key + "}", s.Value);
            } 
            #endregion


            #region 页面基础信息替换
            var ci = Program.CmsInfo;
            foreach (var cms in ci)
            {
                html = html.Replace("{" + cms.Key + "}", cms.Value);
            }
            #endregion

            #region 特殊页面自定义标签
            if(selfkv!=null)
            {
                foreach (var kv in selfkv)
                {
                    html = html.Replace("{" + kv.Key + "}", kv.Value);
                }
            }


            #endregion


            if(Passport.GetPassport(Project.LoginKey)!=null)
            {
                var user = Passport.GetPassport(Project.LoginKey) as Member;

                html = html.Replace("{UserName}", user.NickName.IsNullOrEmpty()?user.Account: user.NickName); 
            }

            return html;
        }



        #region 验证码
        /// <summary>
                /// 数字验证码
                /// </summary>
                /// <returns></returns>
        public FileContentResult NumberVerifyCode()
        {
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.NumberVerifyCode);
            Passport.SetPassport("vocde", code);
            byte[] codeImage = VerifyCodeHelper.GetSingleObj().CreateByteByImgVerifyCode(code, 100, 40);
            return File(codeImage, @"image/jpeg");
        }

        /// <summary>
        /// 字母验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult AbcVerifyCode()
        {
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.AbcVerifyCode);
            Passport.SetPassport("vocde", code);
            var bitmap = VerifyCodeHelper.GetSingleObj().CreateBitmapByImgVerifyCode(code, 100, 40);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            return File(stream.ToArray(), "image/png");
        }

        /// <summary>
        /// 混合验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult MixVerifyCode()
        {
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.MixVerifyCode);
            Passport.SetPassport("vocde", code);
            var bitmap = VerifyCodeHelper.GetSingleObj().CreateBitmapByImgVerifyCode(code, 100, 40);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");
        } 
        #endregion
    }
}
