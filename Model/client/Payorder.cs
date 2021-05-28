using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Payorder
    {
        public Payorder()
        {
            Payordermemberserviceref = new HashSet<Payordermemberserviceref>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime CreateTime { get; set; }
        public int State { get; set; }
        public DateTime? FinishTime { get; set; }
        public DateTime OutTime { get; set; }
        public int Money { get; set; }
        public string OrderNum { get; set; }
        public int PayWay { get; set; }
        public int? PreferentialCodeId { get; set; }
        public string TransactionNum { get; set; }
        public int ProId { get; set; }
        public short IsNew { get; set; }
        public int? MemberServiceId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Memberservice MemberService { get; set; }
        public virtual Preferentialcode PreferentialCode { get; set; }
        public virtual Product Pro { get; set; }
        public virtual ICollection<Payordermemberserviceref> Payordermemberserviceref { get; set; }
    }
}
