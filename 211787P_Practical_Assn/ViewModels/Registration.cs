using _211787P_Practical_Assn.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _211787P_Practical_Assn.ViewModels
{
    public class Registration : ApplicationUser
    {
        [Required]
        //[RegularExpression(@"/^\w+[\+\.\w-]*@([\w-]+\.)*\w+[\w-]*\.([a-z]{2,4}|\d+)$/i")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{12,}$", ErrorMessage = "Passwords must be at least 12 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }

        public static explicit operator Registration(Task<ApplicationUser> v)
        {
            throw new NotImplementedException();
        }

        //public string ReCaptchaToken { get; set; }

    }
}
