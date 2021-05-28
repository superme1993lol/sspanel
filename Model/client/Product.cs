using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Product
    {
        public Product()
        {
            Memberservice = new HashSet<Memberservice>();
            Payorder = new HashSet<Payorder>();
            Preferentialcoderef = new HashSet<Preferentialcoderef>();
            Provpnref = new HashSet<Provpnref>();
        }

        public int Id { get; set; }
        public string ProName { get; set; }
        public DateTime CreateTime { get; set; }
        public int DurationDate { get; set; }
        public long Traffic { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public short IsUse { get; set; }
        public int MaxOnlineUser { get; set; }
        public int FlushTrafficDate { get; set; }

        public virtual ICollection<Memberservice> Memberservice { get; set; }
        public virtual ICollection<Payorder> Payorder { get; set; }
        public virtual ICollection<Preferentialcoderef> Preferentialcoderef { get; set; }
        public virtual ICollection<Provpnref> Provpnref { get; set; }
    }
}
