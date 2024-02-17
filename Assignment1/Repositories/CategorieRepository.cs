using System;
using System.Collections.Generic;
using System.Linq;
using assignment1.Interfaces;
using assignment1.Models;
using Assignment1.CustomExceptions;

namespace assignment1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>()
        {
            new Category {Id = 1, Name = "Fruit"},
            new Category {Id = 2, Name = "Electronic"},
            new Category {Id = 3, Name = "Book"},
            new Category {Id = 4, Name = "Travel"}
        };
        public void Add(Category item)
        {
            _categories.Add(item);
        }
        public void Delete(int id)
        {
            var categoryToRemove = _categories.FirstOrDefault(c => c.Id == id);
            if (categoryToRemove != null)
            {
                _categories.Remove(categoryToRemove);
            }
            else
            {
                throw new ProductOperationException($"Category with ID {id} not found.");
            }
        }
        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }
        public Category GetById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                throw new ProductOperationException($"Category with ID {id} not found.");
            }
            return category;
        }
        public Category Update(Category item)
        {
            var categoryToUpdate = _categories.FirstOrDefault(c => c.Id == item.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = item.Name;
                return categoryToUpdate;
            }
            else
            {
                throw new ProductOperationException($"Category with ID {item.Id} not found.");
            }
        }
    }
}
