using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ssr;
using Model;

namespace DAL
{
    public class SsrUserDAL:BaseDAL_Ssr
    {
        /// <summary>
        /// 传入服务id，获取对应的服务信息
        /// </summary>
        /// <param name="msid"></param>
        /// <returns></returns>
        public User GetById(int msid)
        {
            var dbq = new DBRepository<User>(dbcontext).DbSet;
            var v = dbq.Where(p => p.Pid == msid).FirstOrDefault();
            return v;
        }

    }
}
