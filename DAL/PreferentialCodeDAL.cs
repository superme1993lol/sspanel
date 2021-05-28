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
    public class PreferentialCodeDAL : BaseDAL_Client
    {
        public Preferentialcode GetById(int id)
        {
            var db = new DBRepository<Preferentialcode>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.Id == id).FirstOrDefault();
            return u;
        }

        public Preferentialcode GetNewPC()
        {
            var db = new DBRepository<Preferentialcode>(dbcontext);
            var u = db.DbSet.AsTracking().OrderByDescending(p=>p.CreateTime).FirstOrDefault();
            return u;
        }


        public List<Preferentialcoderef> GetPcRef(int pcid)
        {
            var db = new DBRepository<Preferentialcoderef>(dbcontext);
            var u = db.DbSet.AsTracking().Where(p => p.PreferentialCodeId == pcid).ToList();
            return u;
        }


    }
}
