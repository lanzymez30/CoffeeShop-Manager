using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Entity.Entities
{
    public class Table
    {
        public int TableId { get; set; }
        public string TableName { get; set; } = null!;
        public int Capacity { get; set; }
        public string Status { get; set; } = "Available"; // Available/Occupied/Reserved
        public int? CurrentOrderId { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
