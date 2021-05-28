using System;
using System.Collections.Generic;

namespace Model.admin
{
    public partial class Admininfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
