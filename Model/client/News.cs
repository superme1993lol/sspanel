using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public short IsUse { get; set; }
    }
}
