using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.ViewModels.IdentityViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<UserListItemViewModel> Users { get; set; }
    }
}
