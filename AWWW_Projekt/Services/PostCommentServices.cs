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

        public CommentListItemViewModel GetComment(int id)
        {
            var comment = _context.PostComments
                .Where(b => b.Id == id)
                .FirstOrDefault();

            var vm = new CommentListItemViewModel
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CommentAuthor = comment.CommentAuthor
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

        public void DeletePost(int id)
        {
            var Comment = _context.PostComments.Find(id);
            _context.PostComments.Remove(Comment);
            _context.SaveChanges();
        }

        public void UpdateComment(int id,string title,string content, string commentAuthor)
        {
            var commentINDB = _context.PostComments
                .Where(b => b.Id == id)
                .FirstOrDefault();
            commentINDB.Title = title;
            commentINDB.Content = content;
            commentINDB.CommentAuthor = commentAuthor;

            _context.PostComments.Update(commentINDB);
            _context.SaveChanges();
        }

    }
}
