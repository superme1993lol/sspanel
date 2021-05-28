using System;
using System.Collections.Generic;

namespace Model.client
{
    public partial class Knowledgetype
    {
        public Knowledgetype()
        {
            Knowledge = new HashSet<Knowledge>();
        }

        public int Id { get; set; }
        public string Kname { get; set; }

        public virtual ICollection<Knowledge> Knowledge { get; set; }
    }
}
