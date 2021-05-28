using Model.admin;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Linq;

namespace DAL
{
    public class ChildSystemDAL : BaseDAL_Admin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Childsystem> GetAll()
        {
            var db = new DBRepository<Childsystem>(dbcontext);
            var q = db.DbSet.Where(p => true);
            var lst = q.ToList();
            return lst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Childsystem GetById(int id)
        {
            var db = new DBRepository<Childsystem>(dbcontext);
            var q = db.DbSet.Where(p => p.Id==id);
            return q.FirstOrDefault();
        }


        public Childsystem GetByCName(string cname)
        {
            var db = new DBRepository<Childsystem>(dbcontext);
            var q = db.DbSet.Where(p => p.Cname == cname);
            return q.FirstOrDefault();
        }
    }
}
