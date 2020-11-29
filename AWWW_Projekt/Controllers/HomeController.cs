using AWWW_Projekt.Models;
using AWWW_Projekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Controllers
{
    public class HomeController : Controller
    {
        private PostListService _postListService;
        public HomeController(PostListService postListService)
        {
            _postListService = postListService;
            ViewData["Title"] = "Animal Blog";
        }

        public IActionResult Index()
        {
            var vm = _postListService.GetAllPosts();
            return View(vm);
        }

        

        

        public IActionResult Rate(int id)
        {
            if (id != 0)
            {
                _postListService.CounterUp(id);
            }

            return RedirectToAction("Index");

        }

        public IActionResult RateDown (int id)
        {
            if(id != 0)
            {
                _postListService.CounterDown(id);
            }

            return RedirectToAction("Index");
        }
    }
}
