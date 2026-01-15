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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Order CreateOrder(int tableId, int userId)
        {
            var table = _uow.Tables.GetById(tableId);
            if (table == null)
                throw new InvalidOperationException("Không tìm thấy bàn");

            if (table.Status == "Occupied")
                throw new InvalidOperationException("Bàn đang được sử dụng");

            var order = new Order
            {
                TableId = tableId,
                UserId = userId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = 0
            };

            _uow.Orders.Insert(order);
            _uow.Save();

            table.Status = "Occupied";
            table.CurrentOrderId = order.OrderId;
            _uow.Tables.Update(table);
            _uow.Save();

            return order;
        }

        public void AddOrderDetail(int orderId, int productId, int quantity, string? note = null)
        {
            var product = _uow.Products.GetById(productId);
            if (product == null || !product.IsAvailable)
                throw new InvalidOperationException("Sản phẩm không khả dụng");

            var existingDetail = _uow.OrderDetails
                .GetAll(od => od.OrderId == orderId && od.ProductId == productId)
                .FirstOrDefault();

            if (existingDetail != null)
            {
                existingDetail.Quantity += quantity;
                _uow.OrderDetails.Update(existingDetail);
            }
            else
            {
                var detail = new OrderDetail
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    Note = note
                };
                _uow.OrderDetails.Insert(detail);
            }

            _uow.Save();
            UpdateOrderTotal(orderId);
        }

        public void RemoveOrderDetail(int orderDetailId)
        {
            var detail = _uow.OrderDetails.GetById(orderDetailId);
            if (detail == null)
                throw new InvalidOperationException("Không tìm thấy chi tiết order");

            int orderId = detail.OrderId;
            _uow.OrderDetails.Delete(orderDetailId);
            _uow.Save();
            UpdateOrderTotal(orderId);
        }

        private void UpdateOrderTotal(int orderId)
        {
            var order = _uow.Orders.GetById(orderId);
            if (order == null) return;

            var details = _uow.OrderDetails.GetAll(od => od.OrderId == orderId);
            order.TotalAmount = details.Sum(d => d.Quantity * d.UnitPrice);

            _uow.Orders.Update(order);
            _uow.Save();
        }

        public decimal CalculateTotal(int orderId)
        {
            var details = _uow.OrderDetails.GetAll(od => od.OrderId == orderId);
            return details.Sum(d => d.Quantity * d.UnitPrice);
        }

        public void PayOrder(int orderId, decimal discount = 0)
        {
            var order = _uow.Orders.GetById(orderId);
            if (order == null)
                throw new InvalidOperationException("Không tìm thấy order");

            order.Discount = discount;
            order.TotalAmount = CalculateTotal(orderId) - discount;
            order.PaymentDate = DateTime.Now;
            order.Status = "Paid";

            _uow.Orders.Update(order);

            var table = _uow.Tables.GetById(order.TableId);
            if (table != null)
            {
                table.Status = "Available";
                table.CurrentOrderId = null;
                _uow.Tables.Update(table);
            }

            _uow.Save();
        }

        public Order? GetOrderByTable(int tableId)
        {
            return _uow.Orders
                .GetAll(o => o.TableId == tableId && o.Status == "Pending",
                        includeProperties: "OrderDetails.Product")
                .FirstOrDefault();
        }

        public IEnumerable<Order> GetOrdersByDate(DateTime date)
        {
            return _uow.Orders.GetAll(
                o => o.OrderDate.Date == date.Date,
                includeProperties: "Table,User");
        }

        public IEnumerable<OrderDetail> GetOrderDetails(int orderId)
        {
            return _uow.OrderDetails.GetAll(
                od => od.OrderId == orderId,
                includeProperties: "Product");
        }
    }
}