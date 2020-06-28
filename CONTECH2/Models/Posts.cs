using System;
using System.Collections.Generic;

namespace CONTECH2.Models
{
    public partial class Posts
    {
        public Posts()
        {
            PostsLabels = new HashSet<PostsLabels>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public long? Views { get; set; }
        public long? Likes { get; set; }
        public long? Unlikes { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<PostsLabels> PostsLabels { get; set; }
    }
}
