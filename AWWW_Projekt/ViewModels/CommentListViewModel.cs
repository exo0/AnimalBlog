using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.ViewModels
{
    public class CommentListViewModel
    {
        public IEnumerable<CommentListItemViewModel> Comments { get; set; }
    }
}
