using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment1.Interfaces;
using assignment1.Models;

namespace assignment1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public void ForSale(int productId)
        {
            var product = GetProductById(productId);

            if (product == null)
            {
                Console.WriteLine($"Product with ID {productId} not found.");
                return;
            }
            if (product.AvailableQuantity < 50)
            {
                product.Price *= 0.5m;
                _productRepository.Update(product);
                Console.WriteLine($"Price of {product.Name} reduced by 50% to {product.Price}.");
            }
            if (product.AvailableQuantity < 150)
            {
                product.Price *= 0.8m;
                _productRepository.Update(product);
                Console.WriteLine($"Price of {product.Name} reduced by 20% to {product.Price}.");
            }
            if (product.AvailableQuantity < 400)
            {
                product.Price *= 0.9m;
                _productRepository.Update(product);
                Console.WriteLine($"Price of {product.Name} reduced by 50% to {product.Price}.");
            }
            else
            {
                System.Console.WriteLine("No Discount For that Product");
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetProductsByCategory(Category category)
        {
            return _productRepository.GetAll().Where(product => product.Category.Id == category.Id);
        }

        public Product SellProductInfo(int productId, int quantity)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                Console.WriteLine($"Product with ID {productId} not found.");
                return null;
            }
            if (quantity <= 0)
            {
                Console.WriteLine("Quantity should be greater than zero.");
                return null;
            }
            if (quantity > product.AvailableQuantity)
            {
                Console.WriteLine($"Not enough quantity available. Available quantity: {product.AvailableQuantity}");
                return null;
            }
            var oldQuantity = product.AvailableQuantity;
            product.AvailableQuantity -= quantity;
            _productRepository.Update(product);
            Console.WriteLine($"Sold {quantity} units of {product.Name}.Was:{oldQuantity} Now New available quantity Is: {product.AvailableQuantity}");
            return product;
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }
    }
}