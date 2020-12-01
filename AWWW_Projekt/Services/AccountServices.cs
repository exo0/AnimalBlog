using AWWW_Projekt.Models;
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
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ProjectContext context;

        public AccountServices(UserManager<IdentityUser> _usermanager,
            SignInManager<IdentityUser> _signInManager,
            ProjectContext _context)
        {
            userManager = _usermanager;
            signInManager = _signInManager;
            context = _context;
        }

        


    }
}
