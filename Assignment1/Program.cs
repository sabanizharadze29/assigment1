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

            // get all products
            ProductLogger.GetAndPrintAllProducts(productService);

            // get product by id
            ProductLogger.PrintProductById(productService, 1);
            // add product
            ProductLogger.PrintAddedProduct(productService, new Product { Id = 12, Name = "Apple", Price = 1.2m, Description = "Fresh apple", Category = categoryRepository.GetById(1), AvailableQuantity = 21 });


            // delete product
            ProductLogger.PrintDeleteProduct(productService, 1);
            // update product
            ProductLogger.PrintUpdatedProduct(productService, 3);
            //get products by category
            Category category = categoryRepository.GetById(2);
            ProductLogger.PrintAndGetProductsByCategory(productService, category);



            //For Sale check id=2 product
            productService.ForSale(2);
            // SellProductInfo
            Product soldProduct = productService.SellProductInfo(2, 30);

            // show result
            System.Console.WriteLine("\nResult:");
            ProductLogger.GetAndPrintAllProducts(productService);

        }



    }
}
