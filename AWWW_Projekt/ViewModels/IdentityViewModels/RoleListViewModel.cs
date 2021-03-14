using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.ViewModels.IdentityViewModels
{
    public class RoleListViewModel
    {
        public IEnumerable<RoleListItemViewModel> Roles { get; set; }
    }
}
