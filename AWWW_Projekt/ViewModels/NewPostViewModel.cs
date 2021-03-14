using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AWWW_Projekt.Models;

namespace AWWW_Projekt.ViewModels
{
    public class NewPostViewModel
    {
        [Required(ErrorMessage = "Musisz podać tytuł")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool allowComment { get; set; }
        public int CategoryId { get; set; }
        
    }
}
