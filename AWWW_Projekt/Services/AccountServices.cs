using AWWW_Projekt.Models;
using AWWW_Projekt.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Services
{
    public class AccountServices 
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ProjectContext context;

        public AccountServices(UserManager<User> _usermanager,
            SignInManager<User> _signInManager,
            ProjectContext _context)
        {
            userManager = _usermanager;
            signInManager = _signInManager;
            context = _context;
        }
        public UserListViewModel GetAllUsers()
        {
            var vm = new UserListViewModel
            {
                Users = context.Users.Select(x => new UserListItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname
                    
                })
            };
            return vm;
        }


    }
}
