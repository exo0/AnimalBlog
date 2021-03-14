using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWWW_Projekt.Services;
using AWWW_Projekt.ViewModels;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
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
        [Authorize(Roles = "Admin,User")]
        public IActionResult Delete(int id)
        {
            var vm = _commentservices.GetComment(id);
            return View(vm);
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult DeleteConfirmed(int id)
        {
            _commentservices.DeletePost(id);
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult Edit(int id)
        {
            var vm = _commentservices.GetComment(id);
            return View(vm);
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult EditComment(int id, string title,string content,string commentAuthor)
        {
            _commentservices.UpdateComment(id,title,content,commentAuthor);
            
            return RedirectToAction("Index", "Home");
        }

    }
}
