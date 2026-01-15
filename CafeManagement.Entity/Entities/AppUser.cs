using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Entity.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "Staff"; // Admin/Staff
        public bool IsActive { get; set; } = true;
        public string FullName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}