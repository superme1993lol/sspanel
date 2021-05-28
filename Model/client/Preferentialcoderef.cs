using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Preferentialcoderef
    {
        public int Id { get; set; }
        public int ProId { get; set; }
        public int PreferentialCodeId { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Preferentialcode PreferentialCode { get; set; }
        public virtual Product Pro { get; set; }
    }
}
