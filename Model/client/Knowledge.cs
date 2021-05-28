using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Knowledge
    {
        public int Id { get; set; }
        public int KtypeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public short IsUse { get; set; }

        public virtual Knowledgetype Ktype { get; set; }
    }
}
