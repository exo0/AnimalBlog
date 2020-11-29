using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.ViewModels
{
    public class NewCommentViewModel
    {
        [Required(ErrorMessage = "Musisz podać tytuł")]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
