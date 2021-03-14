using AWWW_Projekt.Models;
using System;
using System.Collections.Generic;

namespace AWWW_Projekt.ViewModels
{
    public class PostListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool allowComment { get; set; }
        public ICollection<Tag> Tags { get; set; }
        // Dodane przeze mnie
        public ICollection<PostComment> Comments { get; set; }
        public DateTime CreatedTime { get; set; }
        public ICollection<Category> Categories { get; set; }
        public int CategoryId { get; set; }
        public double Rating { get; set; }
    }
}
