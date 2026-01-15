using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Entity.Entities;

namespace CafeManagement.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CafeContext _context;

        public IGenericRepository<AppUser> AppUsers { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Table> Tables { get; }
        public IGenericRepository<Order> Orders { get; }
        public IGenericRepository<OrderDetail> OrderDetails { get; }
        public IGenericRepository<Shift> Shifts { get; }

        public UnitOfWork(CafeContext context)
        {
            _context = context;
            AppUsers = new GenericRepository<AppUser>(_context);
            Categories = new GenericRepository<Category>(_context);
            Products = new GenericRepository<Product>(_context);
            Tables = new GenericRepository<Table>(_context);
            Orders = new GenericRepository<Order>(_context);
            OrderDetails = new GenericRepository<OrderDetail>(_context);
            Shifts = new GenericRepository<Shift>(_context);
        }

        public int Save() => _context.SaveChanges();

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}