using _211787P_Practical_Assn.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _211787P_Practical_Assn.Pages
{
    public class LogoutModel : PageModel
    {

        private readonly SignInManager<ApplicationUser> signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            HttpContext.Session.Clear();

            await signInManager.SignOutAsync();
            return RedirectToPage("Login");
        }

        public async Task<IActionResult> OnPostDontLogoutAsync()
        {
            return RedirectToPage("Index");
        }


    }
}
