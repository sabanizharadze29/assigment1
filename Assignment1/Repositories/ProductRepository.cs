using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment1.Interfaces;
using assignment1.Models;
using Assignment1.CustomExceptions;

namespace assignment1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        private List<Product> _products = new List<Product>();
        public ProductRepository(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            InitializeProducts();
        }
        private void InitializeProducts()
        {
            var categories = _categoryRepository.GetAll().ToList();
            _products = new List<Product>()
            {
            new Product {Id = 1, Name = "Banana", Price = 1.5m, Description = "Banana Descr", Category = _categoryRepository.GetById(1), AvailableQuantity = 100 },
            new Product {Id = 2, Name = "Grapes", Price = 3.2m, Description = "Grapes Descr", Category = _categoryRepository.GetById(1), AvailableQuantity = 150 },
            new Product {Id = 3, Name = "Orange", Price = 2.8m, Description = "Orange Descr", Category = _categoryRepository.GetById(1), AvailableQuantity = 200 },
            new Product {Id = 4, Name = "Pineapple", Price = 4.5m, Description = "Pineapple Descr", Category = _categoryRepository.GetById(1), AvailableQuantity = 75 },
            new Product {Id = 5, Name = "Laptop", Price = 899.99m, Description = "Laptop Descr", Category = _categoryRepository.GetById(2), AvailableQuantity = 20 },
            new Product {Id = 6, Name = "Smartphone", Price = 699.99m, Description = "Smartphone Descr", Category = _categoryRepository.GetById(2), AvailableQuantity = 30 },
            new Product {Id = 7, Name = "Headphones", Price = 129.99m, Description = "Headphones Descr", Category = _categoryRepository.GetById(2), AvailableQuantity = 50 },
            new Product {Id = 8, Name = "Book", Price = 19.99m, Description = "Book Descr", Category = _categoryRepository.GetById(3), AvailableQuantity = 100},
            new Product {Id = 9, Name = "Notebook", Price = 9.99m, Description = "Notebook Descr", Category = _categoryRepository.GetById(3), AvailableQuantity = 150 },
            new Product {Id = 10, Name = "Backpack", Price = 49.99m, Description = "Backpack Descr", Category = _categoryRepository.GetById(4), AvailableQuantity = 80 },
            new Product {Id = 11, Name = "Travel Pillow", Price = 15.99m, Description = "Travel Pillow Descr", Category = _categoryRepository.GetById(4), AvailableQuantity = 100 }
            };
        }
        public void Add(Product item)
        {
            _products.Add(item);
        }
        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                throw new ProductOperationException($"Product with ID {id} not found.");
            }
            _products.Remove(product);
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
        public Product GetById(int id)
        {
            var product = _products.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                throw new ProductOperationException($"Product with ID {id} not found.");
            }
            return product;
        }
        public Product Update(Product item)
        {
            var product = _products.FirstOrDefault(product => product.Id == item.Id);
            if (product != null)
            {
                product.Name = item.Name;
                product.Price = item.Price;
                product.Description = item.Description;
                product.AvailableQuantity = item.AvailableQuantity;
                product.Category = _categoryRepository.GetById(item.Id);
                return product;
            }
            throw new ProductOperationException($"Product with ID {item.Id} not found.");
        }
    }
}