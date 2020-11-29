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
        public ICollection<Tag> Tags { get; set; }
        // Dodane przeze mnie
        public ICollection<PostComment> Comments { get; set; }
        public DateTime CreatedTime { get; set; }
        public double Rating { get; set; }
    }
}
