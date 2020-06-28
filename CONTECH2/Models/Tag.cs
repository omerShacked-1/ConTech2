using System;
using System.Collections.Generic;

namespace CONTECH2.Models
{
    public partial class Tag
    {
        public Tag()
        {
            UsersTags = new HashSet<UsersTags>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersTags> UsersTags { get; set; }
    }
}
