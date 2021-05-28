using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Partner
    {
        public Partner()
        {
            Member = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Pwd { get; set; }
        public string RealName { get; set; }
        public string PartnerCode { get; set; }
        public DateTime CreateTime { get; set; }
        public string Remark { get; set; }
        public short IsUse { get; set; }
        public float RoyaltyRate { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
