using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data;
using Vinyls.Data.ViewModels;
using Vinyls.Models;

namespace Vinyls.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager, AppDbContext context)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _context = context;
        }
        public IActionResult Login() => View(new LoginVM());

    }
}
