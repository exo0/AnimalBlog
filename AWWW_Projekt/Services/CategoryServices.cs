using AWWW_Projekt.Models;
using AWWW_Projekt.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Services
{
    public class CategoryServices
    {
        private readonly ProjectContext _context;

        public CategoryServices(ProjectContext context)
        {
            _context = context;
        }

        public CategoryListViewModel GetAllCategories()
        {
            var vm = new CategoryListViewModel
            {
                Categories = _context.Categories.Select(x => new CategoryListItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    //Posts = x.Posts
                })
            };
            return vm;
        }

        public IList<Category> ReturnAllCategoryToDropDown()
        {
            var cat = _context.Categories.ToList();

            IList<Category> categories = new List<Category>();

            foreach(var category in cat)
            {
                categories.Add(new Category
                {
                    Id = category.Id,
                    Title = category.Title
                });
            }

            return categories;
        }

        public CategoryListItemViewModel GetCategory(int id)
        {
            var cat = _context.Categories
                .Where(b => b.Id == id)
                .FirstOrDefault();

            var vm = new CategoryListItemViewModel
            {
                Id = cat.Id,
                Title = cat.Title,
                Posts = cat.Posts
            };
            return vm;
        }

        public void UpdateCategory(int id, string title)
        {
            var catINDB = _context.Categories
                .Where(b => b.Id == id)
                .FirstOrDefault();
            catINDB.Title = title;
            _context.Categories.Update(catINDB);
            _context.SaveChanges();
        }

        public void Add(string Title)
        {
            var cat = new Models.Category
            {
                Title = Title

            };

            _context.Categories.Add(cat);
            _context.SaveChanges();
        }

        public void DeleteCat(int id)
        {
            var cat = _context.Categories.Find(id);
            _context.Categories.Remove(cat);
            _context.SaveChanges();
        }


    }
}
