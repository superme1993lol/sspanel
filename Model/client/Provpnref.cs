using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Provpnref
    {
        public int Id { get; set; }
        public int ProId { get; set; }
        public int Vpnid { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Product Pro { get; set; }
        public virtual Vpnserver Vpn { get; set; }
    }
}
