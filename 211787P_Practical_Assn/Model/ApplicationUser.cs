using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _211787P_Practical_Assn.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Gender { get; set; }

        [Required, MinLength(8, ErrorMessage = "Phone number must be at least 8 digits long"), MaxLength(8, ErrorMessage = "Phone number can only be 8 digits long")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string MobileNo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Image")]
        public string? ImageURL{ get; set; }

        [Display(Name = "AboutMe")]
        public string AboutMe { get; set; }

        [Display(Name = "CreditCard")]
        public string CreditCard { get; set; }
    }
}
