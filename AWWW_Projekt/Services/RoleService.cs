using AWWW_Projekt.Models;
using AWWW_Projekt.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Services
{
    public class RoleService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        private readonly ProjectContext context;
        public RoleService(RoleManager<Role> _roleManager,
            ProjectContext _context)
        {
            roleManager = _roleManager;
            context = _context;
        }
        public RoleListViewModel GetAllRoles()
        {
            var vm = new RoleListViewModel
            {
                Roles = context.Roles.Select(x => new RoleListItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };
            return vm;
        }

        public Role GetRoleById(int id)
        {
            var role = context.Roles.Find(id);

            return role;
        }



        public void DeleteRole(int id)
        {
            var role = context.Roles.Find(id);
            context.Roles.Remove(role);
            context.SaveChanges();
        }



    }
}
