using AWWW_Projekt.Services;
using AWWW_Projekt.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Controllers
{
    public class PostController : Controller
    {
        private PostListService _postListService;
        
        public PostController(PostListService postListService)
        {
            _postListService = postListService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Info(int id)
        {
            var vm = _postListService.GetPost(id);
            return View(vm);
        }
        
        public IActionResult Delete(int id)
        {
            var vm = _postListService.GetPost(id);
            return View(vm);
        }

        
        public IActionResult DeleteConfirmed(int id)
        {
            _postListService.DeletePost(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var vm = _postListService.GetPost(id);
            return View(vm);
        }

        //public IActionResult SaveEdit(PostListItemViewModel data)
        //{
        //    _postListService.Update()
        //}

        public IActionResult Add(NewPostViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            _postListService.Add(data.Title, data.Description, data.Content, data.Tags);

            return RedirectToAction("Index", "Home");
        }
    }
}
