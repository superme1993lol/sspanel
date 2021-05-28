using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.client;
using Model;


namespace DAL
{
    public class ProductDAL : BaseDAL_Client
    {
        public Product GetById(int id)
        {
            var dbq = new DBRepository<Product>(dbcontext).DbSet;
            var v = dbq.Where(p => p.Id == id).FirstOrDefault();
            return v;
        }


        public Product GetNewestProduct()
        {
            var dbq = new DBRepository<Product>(dbcontext).DbSet;
            var v = dbq.OrderByDescending(p=>p.CreateTime).FirstOrDefault();
            return v;
        }


        public List<Product> GetAllInUseProduct()
        {
            var dbq = new DBRepository<Product>(dbcontext).DbSet;
            var v = dbq.Where(p=>p.IsUse==1).OrderBy(p => p.Price).ToList();
            return v;
        }

        public List<Provpnref> GetServerRef(int pid)
        {
            var dbq = new DBRepository<Provpnref>(dbcontext).DbSet;
            var v = dbq.Where(p => p.ProId == pid).ToList();
            return v;
        }


        public bool AddProServerRef(List<int> serverids,int proid,bool issubmit=false)
        {
            try
            {
                var dbq = new DBRepository<Provpnref>(dbcontext);
                var extlst = dbq.DbSet.Where(p => p.ProId == proid).ToList();
                dbq.Delete(extlst);

                foreach (var s in serverids)
                {
                    dbq.Add(new Provpnref { CreateTime = DateTime.Now, ProId = proid, Vpnid = s });
                }
                if(issubmit)
                {
                    dbq.Submit();
                    return true;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
