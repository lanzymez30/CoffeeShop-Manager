using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.BLL.Interfaces;
using CafeManagement.DAL.Repositories;
using CafeManagement.Entity.Entities;

namespace CafeManagement.BLL.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _uow;

        public ReportService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public decimal GetRevenueByDateRange(DateTime from, DateTime to)
        {
            var orders = _uow.Orders.GetAll(
                o => o.PaymentDate.HasValue
                  && o.PaymentDate.Value.Date >= from.Date
                  && o.PaymentDate.Value.Date <= to.Date
                  && o.Status == "Paid");

            return orders.Sum(o => o.TotalAmount);
        }

        public Dictionary<string, int> GetTopSellingProducts(int top = 10)
        {
            var details = _uow.OrderDetails.GetAll(includeProperties: "Product,Order")
                .Where(od => od.Order.Status == "Paid");

            return details
                .GroupBy(od => od.Product.ProductName)
                .OrderByDescending(g => g.Sum(od => od.Quantity))
                .Take(top)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(od => od.Quantity));
        }
    }
}
