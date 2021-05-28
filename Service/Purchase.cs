using Common.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Model.client;
using Model.ssr;

namespace Service
{
    public class Purchase
    {
        static List<string> AllPort  ;


        /// <summary>
        /// 获取ss端口
        /// </summary>
        /// <param name="dbcontext"></param>
        /// <returns></returns>
        public static string GetSsport(stclientContext dbcontext)
        {
            string ssport = "";
            if(AllPort==null)
            {
                AllPort = new List<string>();
                var dbms = new DBRepository<Memberservice>(dbcontext);
                var portlst = dbms.DbQuery.Where(p => p.EndTime > DateTime.Now).Select(p => p.Ssport).ToList();
                for(var i=1;i<50000;i++)
                {
                    //将所有符合
                    AllPort.Add((65535 + i).ToString());
                }
                if(portlst!=null)
                {
                    foreach (var p in portlst)
                    {
                        AllPort.Remove(p);
                    }
                }
                
            }
            if(AllPort.Count==0)
            {
                return "";
            }
            ssport = AllPort[0];
            AllPort.RemoveAt(0);
            return ssport;
        }


        /// <summary>
        /// 完成订单操作
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="dbcontext"></param>
        public bool FinishPay(string orderNum,stclientContext dbcontext,stssrContext dbcontextss)
        {
            PayOrderDAL pod = new PayOrderDAL();
            pod.dbcontext = dbcontext;
            ProductDAL pd = new ProductDAL();
            pd.dbcontext = dbcontext;
            MemberDAL md = new MemberDAL();
            md.dbcontext = dbcontext;
            var dbms = new DBRepository<Memberservice>(dbcontext);
            var dbpo=new DBRepository<Payorder>(dbcontext);
            var dbsu = new DBRepository<User>(dbcontextss);
           

            #region 修改订单状态
            var p = pod.GetByOrderNum(orderNum);
            p.FinishTime = DateTime.Now;
            p.State = 9; 
            #endregion




            #region 在MemberService表中插入/修改对应数据，需要判断是续费还是新增
            Memberservice ms = null;
            string token = "";
            DateTime start;
            DateTime end;
            if (p.MemberServiceId != null)
            {
                ms = md.GetServiceById(p.MemberServiceId.Value);
                var duedate = Convert.ToInt32((ms.EndTime - ms.StartTime).TotalDays);
                start = ms.EndTime;
                end = ms.EndTime.AddDays(duedate);

                ms.EndTime = ms.EndTime.AddDays(duedate);

                if(!dbms.Update(ms, true))
                {
                    return false;
                }
            }
            else
            {
                var pro = pd.GetById(p.ProId);
                token = Guid.NewGuid().ToString();
                var ssport = GetSsport(dbcontext);
                if(ssport.IsNullOrEmpty())
                {
                    return false;
                }
                ms = new Memberservice()
                {
                    MemberId = p.MemberId,
                    FlushTrafficDate = pro.FlushTrafficDate,
                    Ssport = ssport,
                    ProId = p.ProId,
                    MaxOnlineUser = pro.MaxOnlineUser,
                    Token = token,
                    NextDueTime = DateTime.Now.AddDays(pro.FlushTrafficDate),
                    Price = pro.Price,
                    Traffic = pro.Traffic,
                    Sspwd = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(pro.DurationDate)
                };
                start = ms.StartTime;
                end = ms.EndTime;
                if(!dbms.Add(ms, true))
                {
                    return false;
                }
                ms = md.GetServiceByToken(token);
            }
            #endregion


            #region 在 Payordermemberserviceref 表中插入日志数据
            Payordermemberserviceref pomsr = new Payordermemberserviceref()
            {
                StartTime = start,
                EndTime = end,
                CreateTime = DateTime.Now,
                MemberServiceId = ms.Id,
                PayOrderId = p.Id

            };
            var dbpomsr = new DBRepository<Payordermemberserviceref>(dbcontext);
            dbpomsr.Add(pomsr, true);
            #endregion


          
            //对ss数据库进行操作 
            if(!dbsu.DbQuery.Any(p=>p.Pid==ms.Id))
            {
                User u = new User()
                {
                    D = 0,
                    Enable = 1,
                    Maxspeed = 0,
                    Method = "",
                    Obfs = "",
                    Passwd = ms.Sspwd,
                    Pid = ms.Id,
                    Port = ms.Ssport.ToInt().Value,
                    Protocol = "",
                    TransferEnable = ms.Traffic,
                    T = 0,
                    U = 0
                };
                dbsu.Add(u, true);
            }
           


            return true;
        }
    }
}
