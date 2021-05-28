using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service.Pay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model;
using Model.client;
using Model.ssr;

namespace ClientWeb
{
    public class Program
    {
      
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            TimeRun();
        }

        /// <summary>
        /// ��ʱ����
        /// </summary>
        private static void TimeRun()
        {
            Task t = new Task(() =>
            {
                {
                    LoadConfig();
                    var dbweb = new stclientContext(sqlurlWeb);
                    var dbss = new stssrContext(sqlurlSS);

                    var dbms = new DBRepository<Memberservice>(dbweb);
                    var dbsu = new DBRepository<User>(dbss);


                    #region ��ɾ���ķ���
                    var delMs = dbms.DbSet.Where(p => p.EndTime <= DateTime.Now && p.EndTime >= p.NextDueTime).ToList();
                    if (delMs != null && delMs.Count > 0)
                    {
                        for (var i = 0; i < delMs.Count; i++)
                        {
                            //���´�ˢ��ʱ�䳬������ʱ�䣬����������Ѿ������������Ѿ���ss����ɾ��
                            delMs[i].NextDueTime = delMs[i].EndTime.AddDays(1);
                        }
                        dbms.Update(delMs, true);//�޸�web���е�����


                        List<int> delids = delMs.Select(p => p.Id).ToList();
                        var delsu = dbsu.DbSet.Where(p => delids.Contains(p.Pid)).ToList();
                        if (delsu != null && delsu.Count > 0)
                        {
                            dbsu.Delete(delsu, true);//ɾ��ss���е�����
                        }
                    }
                    #endregion


                    #region ��ˢ�������ķ���
                    var upMs = dbms.DbSet.Where(p => p.EndTime > DateTime.Now && p.NextDueTime <= DateTime.Now).ToList();
                    if (upMs != null && upMs.Count > 0)
                    {
                        for (var i = 0; i < upMs.Count; i++)
                        {
                            upMs[i].NextDueTime = upMs[i].NextDueTime.AddDays(upMs[i].FlushTrafficDate);//�������ö�ʱˢ������֮���ʱ��
                            if (upMs[i].NextDueTime > upMs[i].EndTime)
                            {
                                //���ʱ�䳬���˷������ʱ�䣬���Է������ʱ��Ϊ׼
                                upMs[i].NextDueTime = upMs[i].EndTime;
                            }
                        }
                        dbms.Update(upMs, true);//�޸�web���е�����




                        List<int> upids = upMs.Select(p => p.Id).ToList();
                        var upsu = dbsu.DbSet.Where(p => upids.Contains(p.Pid)).ToList();
                        if (upsu != null && upsu.Count > 0)
                        {
                            for (var i = 0; i < upsu.Count; i++)
                            {
                                upsu[i].U = 0;
                                upsu[i].D = 0;
                            }

                            dbsu.Update(upsu, true);//�޸�ss���е�����
                        }
                    }

                    #endregion



                    //���ڼ����ڵķ����Լ���Ҫˢ�������ķ���
                    Thread.Sleep(5 * 60 * 1000);//5����һ��
                }
                while (true) ;
            });
            t.Start();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static List<KeyValuePair<string,string>> sharepage=new List<KeyValuePair<string, string>>();
        public static string sqlurlWeb = "";
        public static string sqlurlSS = "";
        public static string MugApiToken = "";
        public static string Domain = "";
        public static string BgpApiToken = "";
        public static string BgpApiId = "";
        public static string PayWay = "";
        public static string SystemName = "";
        public static string MITM_p12 = "";
        public static string MITM_passphrase = "";

        public static List<KeyValuePair<string, string>> CmsInfo = new List<KeyValuePair<string, string>>();
       

        public static void LoadConfig()
        {
            #region ����ҳ��
            string sharepath = AppContext.BaseDirectory + "template/html/share"; //�����ļ�·��
            DirectoryInfo root = new DirectoryInfo(sharepath);
            var sharefiles = root.GetFiles();
            foreach (var f in sharefiles)
            {
                if (f.Name.Contains(".tpl"))
                {
                    var fname = f.Name.Replace(".tpl", "");
                    var content = Common.MyFile.GetFileString(f.FullName);
                    sharepage.Add(new KeyValuePair<string, string>(fname, content));
                }
            }
            #endregion



            #region �����ļ���Ϣ
            string path = AppContext.BaseDirectory + "conf.cn"; //�����ļ�·��

            var config = GetConfigInfo(path);
            if (config.ContainsKey("sqlurlweb"))
            {
                sqlurlWeb = config["sqlurlweb"].ToString();// web���ݿ�����
            }
            if (config.ContainsKey("sqlurlss"))
            {
                sqlurlSS = config["sqlurlss"].ToString();// ss���ݿ�����
            }
          
            if (config.ContainsKey("Domain"))
            {
                Domain = config["Domain"].ToString();// ������ʽ https://xxxxxx.com
            }


            if (config.ContainsKey("PayWay"))
            {
                PayWay = config["PayWay"].ToString();// ֧����ʽ��Mug����ϱ���Bgp��bgp֧��
            }

            if (config.ContainsKey("MugApiToken"))
            {
                MugApiToken = config["MugApiToken"].ToString();// ��ϱ�֧��token
            }
            if (config.ContainsKey("BgpApiToken"))
            {
                BgpApiToken = config["BgpApiToken"].ToString();// BGP֧��token
            }

            if (config.ContainsKey("BgpApiId"))
            {
                BgpApiId = config["BgpApiId"].ToString();// 
            }
            if (config.ContainsKey("SystemName"))
            {
                SystemName = config["SystemName"].ToString();// 
            }

            if (config.ContainsKey("MITM_p12"))
            {
                MITM_p12 = config["MITM_p12"].ToString();// 
            }
            if (config.ContainsKey("MITM_passphrase"))
            {
                MITM_passphrase = config["MITM_passphrase"].ToString();// 
            }

      
        #endregion


            #region �ͻ�ҳ���Զ�����Ϣ��CMS��
        string cmspath = AppContext.BaseDirectory + "cmsinfo.cn"; //�ͻ�ҳ���Զ�����Ϣ·��
            var cms = GetConfigInfo(cmspath);
            foreach (var k in cms.Keys)
            {
                CmsInfo.Add(new KeyValuePair<string, string>(k.ToString(), cms[k].ToString()));
            }
            CmsInfo.Add(new KeyValuePair<string, string>("Year", DateTime.Now.Year.ToStr()));
            #endregion

        }


        /// <summary>
        /// ��ȡ���������ļ�
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Hashtable GetConfigInfo(string path)
        {
            Hashtable hc = new Hashtable();
            var info = Common.MyFile.GetFileString(path);
            var infos = info.Replace("\r\n", "|").Replace("\n", "|").Replace("\r", "|").Split("|");

            foreach (var inf in infos)
            {
                var iinf = inf;
                if (iinf.Contains("~"))
                {
                    var key = iinf.Split("~")[0];
                    var val = iinf.Split("~")[1];
                    hc.Add(key, val);
                }
            }
            return hc;
        }


        public static BasePay CreatePay()
        {
            BasePay bp;
            switch (Program.PayWay)
            {
                case "Mug":
                    bp = new MugglePay(Program.MugApiToken);
                    break;
                case "Bgp":
                    bp = new BgpPay(Program.BgpApiId, BgpApiToken);
                    break;
                default:
                    bp = new MugglePay(MugApiToken);
                    break;

            }
            return bp;
        }

    }
}
