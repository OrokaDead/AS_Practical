using _211787P_Practical_Assn.Model;
using _211787P_Practical_Assn.ViewModels;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace _211787P_Practical_Assn.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public Login LModel { get; set; }

        private readonly SignInManager<ApplicationUser> signInManager;
        private UserManager<ApplicationUser> UserManager { get; }


        public LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            UserManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await UserManager.FindByEmailAsync(LModel.Email);

                var token = await UserManager.GenerateTwoFactorTokenAsync(appUser, "Email");

                //if (User.Identity.IsAuthenticated)
                //{
                //    return Redirect("/AccessDenied");
                //}
                //var loggedinUser = await UserManager.FindAsync(model.Email, model.Password);
                //if (loggedinUser != null)
                //{
                //    // Now user have entered correct username and password.
                //    // Time to change the security stamp
                //    await UserManager.UpdateSecurityStampAsync(loggedinUser.Id);
                //}

                var identityResult = await signInManager.PasswordSignInAsync(LModel.Email, LModel.Password, LModel.RememberMe, lockoutOnFailure: true);

                if (identityResult.Succeeded)
                {
                    //Create the security context
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, "c@c.com"),
                        new Claim(ClaimTypes.Email, "c@c.com")
                    };
                    var i = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(i);
                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                    return RedirectToPage("Index");
                }

                //if (identityResult.RequiresTwoFactor)
                //{
                //    return RedirectToAction("LoginTwoStep", new { appUser.Email });
                //}
                if (identityResult.RequiresTwoFactor)
                {
                    //return RedirectToPage("LoginVerifyCode", new { id = LModel.Email, returnUrl = "/Login" });
                }
                    // redirect to email verification code page

                    if (identityResult.IsLockedOut)
                {
                    //var forgotPassLink = Url.Action(nameof(ForgotPassword), "Account", new { }, Request.Scheme);
                    //var content = string.Format("Your account is locked out, to reset your password, please click this link: {0}", forgotPassLink);
                    //var message = new Message(new string[] { userModel.Email }, "Locked out account information", content, null);
                    //await _emailSender.SendEmailAsync(message);
                    ModelState.AddModelError("", "The account is locked out for 2 minutes");
                    return Page();
                }

                ModelState.AddModelError("", "Username or Password incorrect");
            }
            return Page();
        }


    }
}
