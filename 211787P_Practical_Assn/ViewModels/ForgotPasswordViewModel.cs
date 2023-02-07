using System.ComponentModel.DataAnnotations;

namespace _211787P_Practical_Assn.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
