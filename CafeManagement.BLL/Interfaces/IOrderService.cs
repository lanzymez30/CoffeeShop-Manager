using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Entity.Entities;

namespace CafeManagement.BLL.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(int tableId, int userId);
        void AddOrderDetail(int orderId, int productId, int quantity, string? note = null);
        void RemoveOrderDetail(int orderDetailId);
        decimal CalculateTotal(int orderId);
        void PayOrder(int orderId, decimal discount = 0);
        Order? GetOrderByTable(int tableId);
        IEnumerable<Order> GetOrdersByDate(DateTime date);
        IEnumerable<OrderDetail> GetOrderDetails(int orderId);
    }
}