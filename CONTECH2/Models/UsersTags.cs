using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace CONTECH2.Models
{
    public partial class UsersTags
    {
        public long UserId { get; set; }
        public long TagId { get; set; }

        [JsonIgnore]
        public virtual Tag Tag { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
