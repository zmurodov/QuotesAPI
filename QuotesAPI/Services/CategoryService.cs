using QuotesAPI.Dtos.Category;
using QuotesAPI.Models;
using QuotesAPI.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace QuotesAPI.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Add(CategoryCreateDto value)
        {
            var category = new Category { Id = _context.IncrementCategoryId(), Name = value.Name };
            _context.Categories.Add(category);
        }
        public void Update(int id, CategoryCreateDto value)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            category.Name= value.Name ?? category.Name;
        }

        public void Remove(int id)
        {
            if (Exists(id))
            {
                _context.Categories.RemoveAt(_context.Categories.FindIndex(c => c.Id == id));
            }
        }


        public bool Exists(int id)
        {
            if (_context.Categories.Count == 0) return false;

            return _context.Categories.FindIndex(q => q.Id == id) != -1;
        }

        public bool Exists(string name)
        {
            if (_context.Categories.Count == 0) return false;

            return _context.Categories.FindIndex(q => q.Name.ToLower() == name.ToLower()) != -1;
        }
    }
}
