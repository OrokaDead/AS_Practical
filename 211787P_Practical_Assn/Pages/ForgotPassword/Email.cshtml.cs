//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.WebUtilities;
//using System.ComponentModel.DataAnnotations;
//using System.Text.Encodings.Web;
//using System.Text;
using _211787P_Practical_Assn.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _211787P_Practical_Assn.Pages.ForgotPassword
{
    public class EmailModel : PageModel
    {
        //        private readonly UserManager<ApplicationUser> _userManager;
        //        private readonly EmailSender _emailSender;

        //        public EmailModel(UserManager<ApplicationUser> userManager, EmailSender emailSender)
        //        {
        //            _userManager = userManager;
        //            _emailSender = emailSender;
        //        }

        //        /// <summary>
        //        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        //        ///     directly from your code. This API may change or be removed in future releases.
        //        /// </summary>
        //        [BindProperty]
        //        public InputModel Input { get; set; }

        //        /// <summary>
        //        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        //        ///     directly from your code. This API may change or be removed in future releases.
        //        /// </summary>
        //        public class InputModel
        //        {
        //            /// <summary>
        //            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        //            ///     directly from your code. This API may change or be removed in future releases.
        //            /// </summary>
        //            [Required]
        //            [EmailAddress]
        //            public string Email { get; set; }
        //        }

        //        public async Task<IActionResult> OnPostAsync()
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var user = await _userManager.FindByEmailAsync(Input.Email);
        //                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
        //                {
        //                    // Don't reveal that the user does not exist or is not confirmed
        //                    TempData["FlashMessage.Type"] = "danger";
        //                    TempData["FlashMessage.Text"] = string.Format("User doesn't exist"); ;
        //                    return Page();
        //                }

        //                // For more information on how to enable account confirmation and password reset please
        //                // visit https://go.microsoft.com/fwlink/?LinkID=532713
        //                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        //                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //                var callbackUrl = Url.Page(
        //                    "/Users/ForgotPassword/ResetPassword",
        //                    pageHandler: null,
        //                    values: new { code, email = user.Email },
        //                    protocol: Request.Scheme);
        //                await _emailSender.Execute("Reset Password", HtmlEncoder.Default.Encode(callbackUrl), Input.Email);
        //                TempData["FlashMessage.Type"] = "success";
        //                TempData["FlashMessage.Text"] = string.Format("Email have been sent"); ;
        //                return Page();
        //            }

        //            return Page();
        //        }
    }
}
