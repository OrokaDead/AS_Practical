using _211787P_Practical_Assn.Model;
using _211787P_Practical_Assn.ViewModels;
using Ganss.Xss;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static System.Collections.Specialized.BitVector32;

namespace _211787P_Practical_Assn.Pages
{
    public class RegistrationModel : PageModel
    {

        private UserManager<ApplicationUser> UserManager { get; }
        private SignInManager<ApplicationUser> SignInManager { get; }

        private readonly RoleManager<IdentityRole> roleManager;

        private IWebHostEnvironment _environment;

        [BindProperty]
        public Registration RModel { get; set; }
        public RegistrationModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment environment, RoleManager<IdentityRole> roleManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            _environment = environment;
            this.roleManager = roleManager;
        }

        [BindProperty]
        public IFormFile? Upload { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {

                var checkEmail = await UserManager.FindByEmailAsync(RModel.Email);
                if (checkEmail != null)
                {
                    ModelState.AddModelError("", "User already exists");
                }

                var sanitizer = new HtmlSanitizer();

                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("s*TY'=k%ppGspSY");

                var user = new ApplicationUser()
                {
                    UserName = sanitizer.Sanitize(RModel.Email),
                    Email = sanitizer.Sanitize(RModel.Email),
                    FullName = sanitizer.Sanitize(RModel.FullName),
                    Gender = RModel.Gender,
                    MobileNo = sanitizer.Sanitize(RModel.MobileNo),
                    AboutMe = sanitizer.Sanitize(RModel.AboutMe),
                    DeliveryAddress = sanitizer.Sanitize(RModel.DeliveryAddress),
                    CreditCard = protector.Protect(sanitizer.Sanitize(RModel.CreditCard)),
                    //TwoFactorEnabled = true
                };

                //var emailDuplicate = await UserManager.SetUserNameAsync(user, RModel.Email);
                //foreach (var error in emailDuplicate.Errors)
                //{
                //    ModelState.AddModelError("", error.Description);
                //}

                if (Upload != null)
                {
                    if (Upload.Length > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Upload", "File size cannot exceed 2MB.");
                        return Page();
                    }
                    var uploadsFolder = "Uploads";
                    var imageFile = Guid.NewGuid() + Path.GetExtension(Upload.FileName);
                    var imagePath = Path.Combine(_environment.ContentRootPath, "wwwroot", uploadsFolder, imageFile);
                    using var fileStream = new FileStream(imagePath, FileMode.Create);
                    await Upload.CopyToAsync(fileStream);
                    user.ImageURL = string.Format("/{0}/{1}", uploadsFolder, imageFile);
                }

                IdentityRole role = await roleManager.FindByIdAsync("Merchant");
                if (role == null)
                {
                    IdentityResult result2 = await roleManager.CreateAsync(new IdentityRole("Merchant"));
                    if (!result2.Succeeded)
                    {
                        ModelState.AddModelError("", "Create role admin failed");
                    }
                }

                var result = await UserManager.CreateAsync(user, RModel.Password);

                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user, "Merchant");

                    await SignInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }
    }
}