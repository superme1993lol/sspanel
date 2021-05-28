using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Workorderdetail
    {
        public int Id { get; set; }
        public int Woid { get; set; }
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
        public int WodType { get; set; }

        public virtual Workorder Wo { get; set; }
    }
}
