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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Product> GetAll()
        {
            return _uow.Products.GetAll(includeProperties: "Category");
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            return _uow.Products.GetAll(
                filter: p => p.CategoryId == categoryId && p.IsAvailable,
                includeProperties: "Category");
        }

        public IEnumerable<Product> SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            keyword = keyword.ToLower();
            return _uow.Products.GetAll(includeProperties: "Category")
                .Where(p => p.ProductName.ToLower().Contains(keyword) ||
                           p.Category.CategoryName.ToLower().Contains(keyword))
                .ToList();
        }

        public Product? GetById(int id)
        {
            return _uow.Products.GetById(id);
        }

        public void Create(Product product)
        {
            if (!ValidateProduct(product, out string error))
                throw new InvalidOperationException(error);

            _uow.Products.Insert(product);
            _uow.Save();
        }

        public void Update(Product product)
        {
            if (!ValidateProduct(product, out string error))
                throw new InvalidOperationException(error);

            _uow.Products.Update(product);
            _uow.Save();
        }

        public void Delete(int id)
        {
            _uow.Products.Delete(id);
            _uow.Save();
        }

        public bool ValidateProduct(Product product, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                error = "Tên sản phẩm không được để trống";
                return false;
            }

            if (product.Price <= 0)
            {
                error = "Giá phải lớn hơn 0";
                return false;
            }

            if (product.CategoryId <= 0)
            {
                error = "Vui lòng chọn danh mục";
                return false;
            }

            return true;
        }
    }
}