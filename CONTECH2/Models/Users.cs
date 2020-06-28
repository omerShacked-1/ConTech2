using System;
using System.Collections.Generic;

namespace CONTECH2.Models
{
    public partial class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
            Teams = new HashSet<Teams>();
            UsersLabels = new HashSet<UsersLabels>();
        }

        public long Id { get; set; }
        public string FullName { get; set; }
        public long? Voip { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public long? Team { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
        public virtual ICollection<UsersLabels> UsersLabels { get; set; }
    }
}
