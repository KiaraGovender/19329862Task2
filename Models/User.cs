using System;
using System.Collections.Generic;

#nullable disable

namespace ACMEINC_19329862.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool? Employee { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
