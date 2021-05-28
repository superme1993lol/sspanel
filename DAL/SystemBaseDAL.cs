using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.client;
using Model;

namespace DAL
{
    public class SystemBaseDAL : BaseDAL_Client
    {
       
        public List<Systembase> GetAll()
        {
            var dbq = new DBRepository<Systembase>(dbcontext).DbSet;
            var lst = dbq.Where(p => p.IsView == 1).ToList();
            return lst;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool Update(List<Systembase> lst)
        {
            try
            {
                List<Systembase> all = GetAll();
                foreach (var item in lst)
                {
                    var im = all.FirstOrDefault(p => p.Key == item.Key);
                    if (im != null) im.Value = item.Value;
                }
                dbcontext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public int GetMaxOnLineUser()
        {
            try
            {
                var dbq = new DBRepository<Systembase>(dbcontext).DbSet;
                var v = dbq.Where(p => p.Key == "MaxOnLineUser").FirstOrDefault();
                if (v != null)
                {
                    return v.Value.ToInt().Value;
                }
                else
                {
                    return 2;
                }
            }
            catch
            {
                return 2;
            }
           
            
        }



        public string GetEmailPostMastr()
        {

            var dbq = new DBRepository<Systembase>(dbcontext).DbSet;
            var v = dbq.Where(p => p.Key == "EmailPostMastr").FirstOrDefault();
            return v.Value; 
        }

        public string GetEmailSystemName()
        {

            var dbq = new DBRepository<Systembase>(dbcontext).DbSet;
            var v = dbq.Where(p => p.Key == "EmailSystemName").FirstOrDefault();
            return v.Value;
        }

        public string GetEmailPassword()
        {

            var dbq = new DBRepository<Systembase>(dbcontext).DbSet;
            var v = dbq.Where(p => p.Key == "EmailPassword").FirstOrDefault();
            return v.Value;
        }


        public string GetEmailSmtpHost()
        {

            var dbq = new DBRepository<Systembase>(dbcontext).DbSet;
            var v = dbq.Where(p => p.Key == "EmailSmtpHost").FirstOrDefault();
            return v.Value;
        }


        public int GetEmailPort()
        {
            try
            {
                var dbq = new DBRepository<Systembase>(dbcontext).DbSet;
                var v = dbq.Where(p => p.Key == "EmailPort").FirstOrDefault();
                if (v != null)
                {
                    return v.Value.ToInt().Value;
                }
                else
                {
                    return 25;
                }
            }
            catch
            {
                return 25;
            }


        }
    }
}
