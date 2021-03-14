using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.ViewModels.CategoryViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<CategoryListItemViewModel> Categories { get; set; }
    }
}
