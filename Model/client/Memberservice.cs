using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Memberservice
    {
        public Memberservice()
        {
            Payorder = new HashSet<Payorder>();
            Payordermemberserviceref = new HashSet<Payordermemberserviceref>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime NextDueTime { get; set; }
        public long Traffic { get; set; }
        public int Price { get; set; }
        public int ProId { get; set; }
        public int MaxOnlineUser { get; set; }
        public int FlushTrafficDate { get; set; }
        public string Sspwd { get; set; }
        public string Ssport { get; set; }
        public string Token { get; set; }

        public virtual Member Member { get; set; }
        public virtual Product Pro { get; set; }
        public virtual ICollection<Payorder> Payorder { get; set; }
        public virtual ICollection<Payordermemberserviceref> Payordermemberserviceref { get; set; }
    }
}
