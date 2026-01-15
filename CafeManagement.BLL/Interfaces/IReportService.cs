using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.BLL.Interfaces
{
    public interface IReportService
    {
        decimal GetRevenueByDateRange(DateTime from, DateTime to);
        Dictionary<string, int> GetTopSellingProducts(int top = 10);
    }
}
