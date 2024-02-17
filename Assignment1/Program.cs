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
            ProductLogger.GetAndPrintAllProducts(productService);
            ProductLogger.PrintProductById(productService, 1);
            ProductLogger.PrintAddedProduct(productService, new Product { Id = 12, Name = "Apple", Price = 1.2m, Description = "Fresh apple", Category = categoryRepository.GetById(1), AvailableQuantity = 21 });
            ProductLogger.PrintDeleteProduct(productService, 1);
            ProductLogger.PrintUpdatedProduct(productService, 3);
            Category category = categoryRepository.GetById(2);
            ProductLogger.PrintAndGetProductsByCategory(productService, category);
            productService.ForSale(2);
            Product soldProduct = productService.SellProductInfo(2, 30);
            System.Console.WriteLine("\nResult:");
            ProductLogger.GetAndPrintAllProducts(productService);
        }
    }
}
