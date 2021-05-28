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
    public class WorkOrderDAL : BaseDAL_Client
    {
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Workorder GetById(int id)
        {
            var db = new DBRepository<Workorder>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.Id == id).FirstOrDefault();
            return u;
        }
         
        public List<Workorder> GetByIds(List<int> ids)
        {
            var db = new DBRepository<Workorder>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => ids.Contains(p.Id)).ToList();
            return u;
        }

        
        public List<Workorderdetail> GetDetailsByWoId(int woid)
        {
            var db = new DBRepository<Workorderdetail>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.Woid==woid).ToList();
            return u;
        }


        public int GetCountByMemberId(int mid)
        {
            var db = new DBRepository<Workorder>(dbcontext);
            var count = db.DbSet.AsTracking().Where(p =>  p.MemberId == mid).Count();
            return count;
        }
    }
}
