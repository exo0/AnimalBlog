using AWWW_Projekt.Models;
using AWWW_Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Services
{
    public class PostListService
    {
        private readonly ProjectContext _context;

        public PostListService(ProjectContext context)
        {
            _context = context;
        }

        public PostListViewModel GetAllPosts()
        {
            var vm = new PostListViewModel
            {
                Posts = _context.Posts.Select(x => new PostListItemViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedTime = DateTime.Now,
                    Description = x.Description,
                    Rating = x.Rating,
                    Title = x.Title,
                    Tags = x.Tags,
                    Comments = x.Comments

                })
            };
            return vm;
        }

        
        public PostListItemViewModel GetPost(int id)
        {
            var post = _context.Posts.Find(id);
            var postId = post.Id;
            var vm = new PostListItemViewModel
            {
                Id = post.Id,
                Content = post.Content,
                CreatedTime = DateTime.Now,
                Description = post.Description,
                Rating = post.Rating,
                Title = post.Title,
                Tags = post.Tags,
                Comments = post.Comments


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
    public void Add(string title, string description, string content, string usrTags)
    {
        var tags = usrTags.Split(',');

        var post = new Models.Post
        {
            Title = title,
            Description = description,
            Content = content,
            Author = new User { Name = "Guest", Login = "Anonymous" },
            AuthorId = 1,
            CreateTime = DateTime.Now,
            UpdateTime = DateTime.Now,
            Tags = tags.Select(x => new Tag { Title = x }).ToList(),
            Comments = new List<PostComment>()
        };

        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    public void DeletePost(int id)
    {
            var Post = _context.Posts.Find(id);
            _context.Posts.Remove(Post);
            _context.SaveChanges();

    }

    public void UpdatePost(string title, string description,string contect,string usrTags)
        {
            var tags = usrTags.Split(',');
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
