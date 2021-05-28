using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.client;
using Model;


namespace DAL
{
    public class VPNServerDAL:BaseDAL_Client
    {
        public Vpnserver GetById(int id)
        {
            var dbq = new DBRepository<Vpnserver>(dbcontext).DbSet;
            var v = dbq.Where(p => p.Id == id).FirstOrDefault();
            return v;
        }

        public List<Vpnserver> GetAllInUse(string ProxyType)
        {
            var dbq = new DBRepository<Vpnserver>(dbcontext).DbSet.Where(p => p.IsUse == 1);
            if(!ProxyType.IsNullOrEmpty())
            {
                dbq = dbq.Where(p => p.ProxyType == ProxyType);
            }
            var lst = dbq.ToList();
            return lst;
        }

    }
}
