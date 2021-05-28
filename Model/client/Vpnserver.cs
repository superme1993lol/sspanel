using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Vpnserver
    {
        public Vpnserver()
        {
            Provpnref = new HashSet<Provpnref>();
        }

        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string ServerName { get; set; }
        public string Country { get; set; }
        public short IsUse { get; set; }
       
        public string Port { get; set; }
        public string Passwd { get; set; }
        public string Method { get; set; }
        public string Obfs { get; set; }
        public string Protocol { get; set; }
        public string Domain { get; set; }
        public float Weight { get; set; }
        public string ProxyType { get; set; }

      
        public virtual ICollection<Provpnref> Provpnref { get; set; }
    }
}
