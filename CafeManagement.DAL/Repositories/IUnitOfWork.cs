using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Entity.Entities;

namespace CafeManagement.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<AppUser> AppUsers { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Table> Tables { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderDetail> OrderDetails { get; }
        IGenericRepository<Shift> Shifts { get; }

        int Save();
    }
}