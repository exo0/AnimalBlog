using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.ViewModels
{
    public class CommentListItemViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CommentAuthor { get; set; }

    }
}
