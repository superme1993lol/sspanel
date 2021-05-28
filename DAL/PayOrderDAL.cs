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
using Model.client;

namespace DAL
{
    public class PayOrderDAL : BaseDAL_Client
    {
        public Payorder GetById(int id)
        {
            var db = new DBRepository<Payorder>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.Id == id).FirstOrDefault();
            return u;
        }

        public Payorder GetByOrderNum(string onum)
        {
            var db = new DBRepository<Payorder>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.OrderNum == onum).FirstOrDefault();
            return u;
        }


        public int GetCountByMemberId(int mid,int state)
        {
            var db = new DBRepository<Payorder>(dbcontext);
            var count = db.DbSet.AsTracking().Where(p =>p.State== state && p.MemberId == mid).Count();
            return count;
        }
    }
}
