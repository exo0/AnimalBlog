using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Models
{

    public class Post
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public double Rating { get; set; }

        //private ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public ICollection<PostComment> Comments { get; set; }

    }
}
