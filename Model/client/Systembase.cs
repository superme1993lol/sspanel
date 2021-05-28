using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Systembase
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateTime { get; set; }
        public short IsView { get; set; }
    }
}
