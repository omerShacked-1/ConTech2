using System;
using System.Collections.Generic;

namespace CONTECH2.Models
{
    public partial class Teams
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public long TeamLeader { get; set; }
        public string Mador { get; set; }
        public string Anaf { get; set; }
        public string Merkaz { get; set; }
        public string Yehida { get; set; }

        public virtual Users TeamLeaderNavigation { get; set; }
    }
}
