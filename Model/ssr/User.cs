using System;
using System.Collections.Generic;

namespace Model.ssr
{
    public partial class User
    {
        public int Pid { get; set; }
        public long U { get; set; }
        public long D { get; set; }
        public int T { get; set; }
        public int Port { get; set; }
        public string Obfs { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public byte Enable { get; set; }
        public string Passwd { get; set; }
        public long TransferEnable { get; set; }
        public int? Maxspeed { get; set; }
    }
}
