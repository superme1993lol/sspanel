using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.ssr;
using DAL;

namespace Service
{
    public class SsDbService
    {
        


        /// <summary>
        /// 获取update数据流量大小
        /// </summary>
        /// <param name="msid"></param>
        /// <returns></returns>
        public static long GetServiceUpdateTraffic(int msid,stssrContext dbcontext)
        {
            DAL.SsrUserDAL sud = new SsrUserDAL();
            sud.dbcontext = dbcontext;
            long t = 0;
             var u=sud.GetById(msid);
            t = u.U;
            return t;
        }

        /// <summary>
        /// 获取下载的数据流量大小
        /// </summary>
        /// <param name="msid"></param>
        /// <returns></returns>
        public static long GetServiceDownloadTraffic(int msid, stssrContext dbcontext)
        {
            DAL.SsrUserDAL sud = new SsrUserDAL();
            sud.dbcontext = dbcontext;
            long t = 0;
            var u = sud.GetById(msid);
            t = u.D;
            return t;
        }


        /// <summary>
        /// 获取上传下载流量总和
        /// </summary>
        /// <param name="msid"></param>
        /// <returns></returns>
        public static long GetServiceAllTraffic(int msid, stssrContext dbcontext)
        {
            DAL.SsrUserDAL sud = new SsrUserDAL();
            sud.dbcontext = dbcontext;
            long t = 0;
            var u = sud.GetById(msid);
            t = u.D+u.U;
            return t;
        }
    }
}
