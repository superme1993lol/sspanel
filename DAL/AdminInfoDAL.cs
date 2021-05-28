using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;
using Model.admin;
using Common.Web;
using System.IO;


namespace DAL
{
    public class AdminInfoDAL: BaseDAL_Admin
    {
        /// <summary>
        /// 账户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Admininfo Login(string account, string pwd, ref string error)
        {

            Admininfo u = null;
            var pwd1 = Common.Str.MD5Encrypt.MD5Deal(pwd);
            var db = new DBRepository<Admininfo>(dbcontext);
            u = db.DbQuery.Where(p => p.UserName == account).FirstOrDefault();
            if (u == null)
            {
                error = "账户不存在";
            }
            else
            {
                if (u.Pwd != pwd1 && u.Pwd != pwd)
                {
                    error = "密码不正确";
                    u = null;
                }
            }
            return u;
        }
         
        public Admininfo GetById(int id)
        {
            var db = new DBRepository<Admininfo>(dbcontext);
            var q = db.DbQuery.Where(p => p.Id == id); 
            return q.FirstOrDefault();
        }
    }
}
