using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.ViewModels
{
    public class PostListViewModel
    {
        public IEnumerable<PostListItemViewModel> Posts { get; set; }
    }
}
