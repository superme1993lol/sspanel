using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Member
    {
        public Member()
        {
             Memberservice = new HashSet<Memberservice>();
            Payorder = new HashSet<Payorder>();
            Preferentialcode = new HashSet<Preferentialcode>();
            Workorder = new HashSet<Workorder>();
        }

        public int Id { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
        public DateTime CreateTime { get; set; }
        public short IsUse { get; set; }
        public string RegistKey { get; set; }
        public short IsRegist { get; set; }
        public string ResetPwdKey { get; set; }
        public short IsMailSend { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public int? PartnerId { get; set; }

        public virtual Partner Partner { get; set; }
    
        public virtual ICollection<Memberservice> Memberservice { get; set; }
        public virtual ICollection<Payorder> Payorder { get; set; }
        public virtual ICollection<Preferentialcode> Preferentialcode { get; set; }
        public virtual ICollection<Workorder> Workorder { get; set; }
    }
}
