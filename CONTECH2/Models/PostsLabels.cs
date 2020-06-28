using System;
using System.Collections.Generic;

namespace CONTECH2.Models
{
    public partial class PostsLabels
    {
        public long PostId { get; set; }
        public long LabelsId { get; set; }

        public virtual Labels Labels { get; set; }
        public virtual Posts Post { get; set; }
    }
}
