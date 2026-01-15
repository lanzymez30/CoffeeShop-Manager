using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Entity.Entities;

namespace CafeManagement.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategory(int categoryId);
        IEnumerable<Product> SearchProducts(string keyword);
        Product? GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
        bool ValidateProduct(Product product, out string error);
    }
}
