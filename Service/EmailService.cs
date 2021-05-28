using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Model.client;
using DAL;

namespace Service
{
    /// <summary>
    /// Email发送
    /// </summary>
    public class EmailBase
    {
        public string PostMasterEmail
        {
            get; set;
        }

        public string SystemName
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string SmtpHost
        {
            get; set;
        }

        public int Port
        {
            get; set;
        }
    }

    public class EmailService
    {
        

        public static EmailBase LaodService(stclientContext db)
        {
            var emailbase = new EmailBase();
            SystemBaseDAL sbd = new SystemBaseDAL();
            sbd.dbcontext = db;
            emailbase.Password = sbd.GetEmailPassword();
            emailbase.Port = sbd.GetEmailPort();
            emailbase.PostMasterEmail = sbd.GetEmailPostMastr();
            emailbase.SmtpHost = sbd.GetEmailSmtpHost();
            emailbase.SystemName = sbd.GetEmailSystemName();
            return emailbase;
        }

        /// <summary>
        /// 发送注册邮件
        /// </summary>
        /// <param name="mid">账户id</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool SendActiveEmail(int mid, string Domain, stclientContext db, string templatePathBase = "")
        {
            MemberDAL md = new MemberDAL();
            md.dbcontext = db;
            var m = md.GetById(mid);
             
            return SendActiveEmail(m.Email,m.RegistKey,  Domain,  db,  templatePathBase);
        }


        public static bool SendActiveEmail(string email,string regkey, string Domain, stclientContext db, string templatePathBase = "")
        {
            MemberDAL md = new MemberDAL();
            md.dbcontext = db;
          
            var eb = LaodService(db);
            string path = AppContext.BaseDirectory + "template/" + templatePathBase + "/email/active.tpl"; // 
            var info = Common.MyFile.GetFileString(path);

            info = info.Replace("{SystemName}", eb.SystemName).Replace("{Domain}", Domain).Replace("{Acode}", regkey).Replace("{CreateTime}", DateTime.Now.ToString("yyyy-MM-dd"));

            return SendEmail(email, info, eb.SystemName + "账户激活邮件", eb);
        }



        #region 基础发邮件


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool SendEmail(string toEmail, string content, string title, stclientContext db)
        {
            var eb = LaodService(db);

            return SendEmail(toEmail, content, title, eb);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="eb"></param>
        /// <returns></returns>
        public static bool SendEmail(string toEmail, string content, string title, EmailBase eb)
        { 
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(toEmail);
            msg.From = new MailAddress(eb.PostMasterEmail, eb.SystemName, System.Text.Encoding.UTF8);
            msg.Subject = title;//邮件标题 
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 
            msg.Body = content;//邮件内容 
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 
            msg.IsBodyHtml = true;//是否是HTML邮件 
            msg.Priority = MailPriority.High;//邮件优先级  

            SmtpClient client = new SmtpClient(eb.SmtpHost, eb.Port);
            client.EnableSsl = false;  // SSL安全连接一定要注意设为 true
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(eb.PostMasterEmail, eb.Password);
            object userState = msg;
            try
            {
                client.Send(msg);

                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {

                return false;

            } 
        }




        #endregion
    }
}
