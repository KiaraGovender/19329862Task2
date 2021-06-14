using System;
using System.Collections.Generic;

#nullable disable

namespace ACMEINC_19329862.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public string Orderdate { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
