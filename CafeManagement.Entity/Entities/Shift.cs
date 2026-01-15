using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Entity.Entities
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public string ShiftName { get; set; } = null!; // Sáng/Chiều/Tối
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? UserId { get; set; }
        public decimal Revenue { get; set; }
        public int OrderCount { get; set; }
        public string? Note { get; set; }

        public AppUser? User { get; set; }
    }
}
