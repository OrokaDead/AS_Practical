using _211787P_Practical_Assn.Model;
using _211787P_Practical_Assn.Pages;
using _211787P_Practical_Assn.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _211787P_Practical_Assn.Controllers
{
    public class Account : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public Account(UserManager<ApplicationUser> usrMgr)
        {
            userManager = usrMgr;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

    }
}
