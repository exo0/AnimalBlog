using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWWW_Projekt.Services;
using AWWW_Projekt.ViewModels;

namespace AWWW_Projekt.Controllers
{
    public class CommentController : Controller
    {
        private PostCommentServices _commentservices;
        

        public CommentController(PostCommentServices commentServices)
        {
            _commentservices = commentServices;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(int Id,NewCommentViewModel comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }

            _commentservices.Add(Id,comment.Title, comment.Content, comment.Author);

            return RedirectToAction("Index", "Home");
        }
        
    }
}
