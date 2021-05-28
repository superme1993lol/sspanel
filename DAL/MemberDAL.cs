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
using Model.client;
using Common.Web;
using System.IO;

namespace DAL
{
    public class MemberDAL:BaseDAL_Client
    {

        #region 基础信息
        /// <summary>
        /// 账户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Member Login(string account, string pwd, ref string error)
        {
            Member u = null;
            var pwd1 = Common.Str.MD5Encrypt.MD5Deal(pwd);
            var db = new DBRepository<Member>(dbcontext);
            u = db.DbSet.Where(p => p.Account == account && p.IsUse == 1).FirstOrDefault();
            if (u == null)
            {
                error = "账户不存在";
            }
            else if(u.IsRegist==0)
            {
                error = "请首先激活账户";
                u = null;
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


        public int GetMaxId()
        {
            var db = new DBRepository<Member>(dbcontext);
            var m = db.DbQuery.OrderByDescending(p => p.CreateTime).FirstOrDefault();
            if(m!=null)
            {
                return 0;
            }
            else
            {
                return m.Id;
            }
        }


        /// <summary>
        /// 判断是否已经存在账户名
        /// </summary>
        /// <param name="account">账户名</param>
        /// <returns></returns>
        public bool IsAccountExit(string account)
        {
            var db = new DBRepository<Member>(dbcontext);
            return db.DbQuery.Any(p => p.Account == account);
        }


        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Member GetById(int id)
        {
            var db = new DBRepository<Member>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.Id == id).FirstOrDefault();
            return u;
        }

        /// <summary>
        /// 根据邮箱获取账户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Member GetByEmail(string email)
        {
            var db = new DBRepository<Member>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.Email == email).FirstOrDefault();
            return u;
        }

        /// <summary>
        /// 根据id列表，获取所有的账户信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<Member> GetByIds(List<int> ids)
        {
            var db = new DBRepository<Member>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => ids.Contains(p.Id)).ToList();
            return u;
        }


        public Member GetByRegCode(string regcode)
        {
            var db = new DBRepository<Member>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.RegistKey == regcode).FirstOrDefault();
            return u;
        }

        #endregion


        #region 服务信息

        public Memberservice GetServiceById(int id)
        {
            var db = new DBRepository<Memberservice>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.Id == id).FirstOrDefault();
            return u;
        }

        public Memberservice GetServiceByToken(string token)
        {
            var db = new DBRepository<Memberservice>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.Token == token).FirstOrDefault();
            return u;
        }


        /// <summary>
        /// 获取当前仍在使用的
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public List<Memberservice> GetServiceByMemberId(int mid)
        {
            var db = new DBRepository<Memberservice>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.MemberId == mid&&p.EndTime>DateTime.Now).OrderBy(p=>p.StartTime).ToList();
            return u;
        }


 
        #endregion



       
    }
}
