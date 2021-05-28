using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Payordermemberserviceref
    {
        public int Id { get; set; }
        public int MemberServiceId { get; set; }
        public int PayOrderId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Memberservice MemberService { get; set; }
        public virtual Payorder PayOrder { get; set; }
    }
}
