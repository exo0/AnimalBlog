using AWWW_Projekt.Services;
using AWWW_Projekt.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Linq;


namespace AWWW_Projekt.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class PostController : Controller
    {
        private PostListService _postListService;
        private CategoryServices _categoryServices;

        public PostController(PostListService postListService,CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
            _postListService = postListService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
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
            var categories = _categoryServices.ReturnAllCategoryToDropDown();
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            });
            var vm = _postListService.GetPost(id);
            return View(vm);
        }
        public IActionResult EditPost(int id, string title, string description,bool allowComment, string content, int CategoryId)
        {
                _postListService.UpdatePost(id, title, allowComment, description, content, CategoryId);
                return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Add()
        {
            var categories = _categoryServices.ReturnAllCategoryToDropDown();
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            });
            return View();
        }

        public async System.Threading.Tasks.Task<IActionResult> Add(NewPostViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            var usr = HttpContext.User.Identity.Name;

            await _postListService.Add(usr,data.Title, data.Description,data.allowComment, data.Content, data.Tags,data.CategoryId);

            return RedirectToAction("Index", "Home");
        }
    }
}
