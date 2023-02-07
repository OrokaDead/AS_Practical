using _211787P_Practical_Assn.Model;
using _211787P_Practical_Assn.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace _211787P_Practical_Assn.Pages
{

    [Authorize]
    public class IndexModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";

        private readonly ILogger<IndexModel> _logger;
        private IdentityDbContext<ApplicationUser> _context;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private UserManager<ApplicationUser> UserManager { get; }
        private SignInManager<ApplicationUser> SignInManager { get; }
        private IWebHostEnvironment _environment;

        [BindProperty]
        public Registration RModel { get; set; }

        public async void OnGet()
        {

            //var FullName = UserManager.FindByEmailAsync(User.Identity.Name).Result.FullName;

            //var users = _context.Users.ToList();

            //var users = UserManager.Users.ToList();

            //foreach (var user in users)
            //{
            //    if (user.Email == SessionKeyName)
            //    {
            //        RModel = (Registration)user;
            //    }
            //}

            //var userId = UserManager.GetUserId(HttpContext.User);
            //ApplicationUser user = UserManager.FindByIdAsync(userId).Result;

            //var user = await UserManager.GetUserAsync(_context.HttpContext.User);

            //RModel = (Registration)UserManager.GetUserAsync(User);

            //var user = await GetCurrentUserAsync();

            //var userId = user.Id;
            //var user = await UserManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");
            //}

            //ApplicationUser? user = await UserManager.GetUserAsync(HttpContext.User);

            var currentUserName = User.Identity.Name;

            //var result = context.Users.Where(u => u.email == userEmail).ToList();

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, $"{User.Identity.Name}");
                HttpContext.Session.SetInt32(SessionKeyAge, 73);
            }
            var name = HttpContext.Session.GetString(SessionKeyName);
            var age = HttpContext.Session.GetInt32(SessionKeyAge).ToString();

            _logger.LogInformation("Session Name: {Name}", name);
            _logger.LogInformation("Session Age: {Age}", age);
        }
    }
}