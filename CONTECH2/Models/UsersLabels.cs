using System;
using System.Collections.Generic;

namespace CONTECH2.Models
{
    public partial class UsersLabels
    {
        public long UserId { get; set; }
        public long LabelsId { get; set; }

        public virtual Labels Labels { get; set; }
        public virtual Users User { get; set; }
    }
}
