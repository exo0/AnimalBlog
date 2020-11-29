using System;
using AWWW_Projekt.Models;
using AWWW_Projekt.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Services
{
    public class PostCommentServices
    {
        private readonly ProjectContext _context;

        public PostCommentServices(ProjectContext context)
        {
            _context = context;
        }

        public CommentListViewModel GetAllComments()
        {
            var vm = new CommentListViewModel
            {
                Comments = _context.PostComments.Select(x => new CommentListItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CommentAuthor = x.CommentAuthor


                })
            };
            return vm;
        }

        public void Add(int PostId,string title, string content,string commentauthor)
        {
            
            var currentPostId = _context.Posts.First(s => s.Id == PostId).Id;
            var Comment = new Models.PostComment
            {
                PostId = currentPostId,
                Title = title,
                Content = content,
                CommentAuthor = commentauthor
            };     

            _context.PostComments.Add(Comment);         
            _context.SaveChanges();

        }
    }
}
