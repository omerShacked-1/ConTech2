using System;
using System.Collections.Generic;

namespace CONTECH2.Models
{
    public partial class Labels
    {
        public Labels()
        {
            PostsLabels = new HashSet<PostsLabels>();
            UsersLabels = new HashSet<UsersLabels>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PostsLabels> PostsLabels { get; set; }
        public virtual ICollection<UsersLabels> UsersLabels { get; set; }
    }
}
