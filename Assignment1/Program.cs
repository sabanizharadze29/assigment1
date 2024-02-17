using System;
using System.Collections.Generic;
using assignment1.Interfaces;
using assignment1.Models;
using assignment1.Repositories;
using assignment1.Services;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            IProductRepository productRepository = new ProductRepository(categoryRepository);
            IProductService productService = new ProductService(productRepository, categoryRepository);
            try
            {
                productService.GetAllProducts();

                productService.GetProductById(1);

                productService.AddProduct(new Product { Id = 12, Name = "Apple", Price = 1.2m, Description = "Fresh apple", Category = categoryRepository.GetById(1), AvailableQuantity = 21 });

                productService.DeleteProduct(1);

                var updatedProduct = new Product { Id = 3, Name = "Updated Name", Price = 2.5m, Description = "Updated description", AvailableQuantity = 10, Category = categoryRepository.GetById(2) };
                productService.UpdateProduct(updatedProduct);

                var category = categoryRepository.GetById(2);
                productService.GetProductsByCategory(category);

                productService.SellProductInfo(2, 30);

            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }

        private static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
