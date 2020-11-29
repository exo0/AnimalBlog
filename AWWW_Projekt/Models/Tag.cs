using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWWW_Projekt.Models
{
    /// <summary>
    /// Used for filtering and categorizing posts
    /// </summary>
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// How this tag is called
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Brief description of the tag
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
