using AWWW_Projekt.Services;
using AWWW_Projekt.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class CategoryController : Controller
    {
        private CategoryServices _categoryService;

        public CategoryController(CategoryServices categoryServices)
        {
            _categoryService = categoryServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Index()
        {
            var vm = _categoryService.GetAllCategories();
            return View(vm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(NewCategoryViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            _categoryService.Add(data.Title);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var vm = _categoryService.GetCategory(id);
            return View(vm);
        }

        public IActionResult EditCategory(int id, string title)
        {
            _categoryService.UpdateCategory(id, title);
            return RedirectToAction("Index", "Home");
        }
        //public IActionResult Info(int id)
        //{
        //    var vm = _categoryService.GetCategory(id);
        //    return View(vm);
        //}

        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCat(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
