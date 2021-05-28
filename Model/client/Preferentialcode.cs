using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Preferentialcode
    {
        public Preferentialcode()
        {
            Payorder = new HashSet<Payorder>();
            Preferentialcoderef = new HashSet<Preferentialcoderef>();
        }

        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Code { get; set; }
        public short IsUse { get; set; }
        public float? Discount { get; set; }
        public int? MemberId { get; set; }
        public DateTime? UseTime { get; set; }
        public short IsDelete { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<Payorder> Payorder { get; set; }
        public virtual ICollection<Preferentialcoderef> Preferentialcoderef { get; set; }
    }
}
