using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.client;
using Model;
namespace DAL
{
    public class NewsDAL:BaseDAL_Client
    {
        /// <summary>
        /// 获取最新的新闻公告
        /// </summary>
        /// <returns></returns>
        public News GetLastNews()
        {
            var dbq = new DBRepository<News>(dbcontext).DbSet;
            var n = dbq.Where(p => p.IsUse == 1).OrderByDescending(p=>p.CreateTime).FirstOrDefault();
            return n;
        }

        public News GetById(int id)
        {
            var dbq = new DBRepository<News>(dbcontext).DbSet;
            var d = dbq.Where(p => p.Id == id).FirstOrDefault();
            return d;
        }


        public int GetCountInUse()
        {
            try
            {
                var dbq = new DBRepository<News>(dbcontext).DbSet;
                var d = dbq.Where(p => p.IsUse == 1).Count();
                return d;
            }
            catch
            {
                return 0;
            }
        }
    }
}
