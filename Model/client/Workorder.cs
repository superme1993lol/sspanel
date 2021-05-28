using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Workorder
    {
        public Workorder()
        {
            Workorderdetail = new HashSet<Workorderdetail>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime CreateTime { get; set; }
        public int State { get; set; }
        public string Content { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<Workorderdetail> Workorderdetail { get; set; }
    }
}
