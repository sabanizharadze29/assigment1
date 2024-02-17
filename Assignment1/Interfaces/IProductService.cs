using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment1.Models;

namespace assignment1.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> GetProductsByCategory(Category category);
        Product SellProductInfo(int productId, int quantity);
        void ForSale(int productId);
    }
}