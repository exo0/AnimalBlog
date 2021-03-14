using AWWW_Projekt.Models;
using AWWW_Projekt.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace AWWW_Projekt.Services
{
    public class PostListService
    {
        private readonly ProjectContext _context;
        private SignInManager<User> SignInManager;
        private UserManager<User> UserManager;
        //private readonly CategoryServices _categoryServices;

        public PostListService(ProjectContext context, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context;
            SignInManager = signInManager;
            UserManager = userManager;
            //_categoryServices = categoryServices;
        }



        public PostListViewModel GetAllPosts()
        {
            var vm = new PostListViewModel
            {
                Posts = _context.Posts.Select(x => new PostListItemViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedTime = x.CreateTime,
                    Description = x.Description,
                    allowComment = x.allowComment,
                    Rating = x.Rating,
                    Title = x.Title,
                    Tags = x.Tags,
                    Comments = x.Comments,
                    Categories = x.Categories

                })
            };
            return vm;
        }

        public PostListViewModel GetAllPostFiltered(string searchString)
        {
            
            var vm = new PostListViewModel
            {
                Posts = _context.Posts
                .Include(e=> e.Tags)
                .Where(e=> e.Tags.Any(i=>i.Title.Contains(searchString)))
                .Select(x => new PostListItemViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedTime = x.CreateTime,
                    Description = x.Description,
                    allowComment = x.allowComment,
                    Rating = x.Rating,
                    Title = x.Title,
                    Tags = x.Tags,
                    Comments = x.Comments,
                    Categories = x.Categories

                })
                
                
            };
            return vm;
        }

        
        public PostListItemViewModel GetPost(int id)
        {
            //var post = _context.Posts.Find(id);
            var post = _context.Posts
                .Where(b => b.Id == id)
                .Include(b => b.Tags)
                .Include(b=> b.Categories)
                .FirstOrDefault();
            var postId = post.Id;

            var vm = new PostListItemViewModel
            {
                Id = post.Id,
                Content = post.Content,
                CreatedTime = post.CreateTime,
                Description = post.Description,
                Rating = post.Rating,
                allowComment = post.allowComment,
                Title = post.Title,
                Tags = post.Tags,
                Comments = post.Comments,
                Categories = post.Categories


            };
            return vm;
        }

        


    //private void TagCreator(IEnumerable<string> tags)
    //{
    //    var toCreate = new List<Tag>();

    //    foreach (var tag in tags)
    //    {
    //        if (_context.Find(typeof(Tag), tag))
    //    }
    //}

    /// <summary>
    /// Creates new post
    /// </summary>
    public async Task Add(string usrId,string title, string description,bool _allowComment, string content, string usrTags,int categoryId)
    {
            var tags = usrTags.Split(',');
            Category cat = _context.Categories.Find(categoryId);
            var ussr = await UserManager.FindByNameAsync(usrId);
            

            var post = new Models.Post
            {
                Title = title,
                Description = description,
                Content = content,
                Author = ussr,
                AuthorId = 1,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                allowComment = _allowComment,
                Tags = tags.Select(x => new Tag { Title = x }).ToList(),
                Comments = new List<PostComment>(),
                Categories = new List<Category>()
        };
            post.Categories.Add(cat);
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    public void DeletePost(int id)
    {
            var Post = _context.Posts.Find(id);
            _context.Posts.Remove(Post);
            _context.SaveChanges();

    }

    public void UpdatePost(int id, string title,bool _allowComment,string description,string contect,int CategoryId)
        {
            //var postINDB = _context.Posts.Find(id);
            var cat = _context.Categories.Find(CategoryId);
            var postINDB = _context.Posts
                .Where(b => b.Id == id)
                .Include(b => b.Tags)
                .Include(b => b.Categories)
                .FirstOrDefault();
            if (postINDB.Categories.Count() == 0)
            {

            }
            else
            {
                var currentCat = postINDB.Categories.First();
                if (id == postINDB.Id)
                {
                    postINDB.Title = title;
                    postINDB.Description = description;
                    postINDB.Content = contect;
                    postINDB.allowComment = _allowComment;
                    postINDB.Categories.Remove(currentCat);
                    postINDB.Categories.Add(cat);

                }
            }
            _context.Posts.Update(postINDB);
            _context.SaveChanges();
        }
        /// <summary>
        /// Just for testing
        /// </summary>
        /// <param name="id">What post to "boost"</param>
    public void CounterUp(int id)
    {
        var post = _context.Posts.Find(id);

        if (post.Rating >= 5)
        {

        }
        else
        {
            post.Rating += 1;
        }


        _context.Posts.Update(post);

        _context.SaveChanges();
    }

    public void CounterDown(int id)
    {
        var psot = _context.Posts.Find(id);

        if (psot.Rating <= 0)
        {

        }
        else
        {
            psot.Rating -= 1;
        }

        _context.Posts.Update(psot);

        _context.SaveChanges();
    }
}
}
