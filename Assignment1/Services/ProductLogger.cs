using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment1.Interfaces;
using assignment1.Models;

namespace assignment1.Services
{
    public static class ProductLogger
    {
        public static void PrintUpdatedProduct(IProductService productService, int id)
        {
            LogAction($"::::::Updating a product (id = {id} )...\n Old Product:::::::");
            var updatedProduct = productService.GetProductById(id);
            if (updatedProduct != null)
            {
                ProductLogger.PrintProductById(productService, id);
                updatedProduct.Name = "New Name";
                productService.UpdateProduct(updatedProduct);
                LogAdditionalInfo("Product updated successfully. updated Product:");
                ProductLogger.PrintProductById(productService, id);
            }
            else
            {
                System.Console.WriteLine(updatedProduct);
                LogError("Product not found.");
            }
        }
        public static void GetAndPrintAllProducts(IProductService productService)
        {
            LogMainColor("::::::Getting all products...::::::");
            var allProducts = productService.GetAllProducts();
            foreach (var product in allProducts)
            {
                LogAdditionalInfo($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}, Category: {product.Category.Name},AvailableQuantity: {product.AvailableQuantity}");
            }
        }
        public static void PrintProductById(IProductService productService, int productId)
        {
            LogAction($"::::::Getting Product By Id {productId}...::::::");
            var productById = productService.GetProductById(productId);
            if (productById != null)
            {
                LogAdditionalInfo($"Product found: ID: {productById.Id}, Name: {productById.Name}, Price: {productById.Price}, Description: {productById.Description}, Category: {productById.Category.Name}, AvailableQuantity: {productById.AvailableQuantity}");
            }
            else
            {
                LogError("Product not found.");
            }
        }
        public static void PrintAddedProduct(IProductService productService, Product product)
        {
            LogAction(":::::Adding a new product...::::::");
            productService.AddProduct(product);
            LogAdditionalInfo("Product Successfully Added Here is Full List");
            ProductLogger.GetAndPrintAllProducts(productService);
        }
        public static void PrintDeleteProduct(IProductService productService, int id)
        {
            LogAction($":::::: Deleting a  product by id {id}...::::::");
            productService.DeleteProduct(id);
            LogAdditionalInfo("Product deleted successfully.Full List:");
            GetAndPrintAllProducts(productService);
        }

        public static void LogMainColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void LogAdditionalInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void LogAction(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrintAndGetProductsByCategory(IProductService productService, Category category)
        {
            LogAction("::::::::Get Products By Category::::::");
            var products = productService.GetProductsByCategory(category);
            foreach (var product in products)
            {
                LogAdditionalInfo($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}, Category: {product.Category.Name}, AvailableQuantity: {product.AvailableQuantity}");

            }
        }
    }
}