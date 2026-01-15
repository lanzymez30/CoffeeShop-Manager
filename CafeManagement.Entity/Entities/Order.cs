using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Entity.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; } = 0;
        public string Status { get; set; } = "Pending"; // Pending/Paid/Cancelled
        public string? Note { get; set; }

        public Table Table { get; set; } = null!;
        public AppUser User { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
