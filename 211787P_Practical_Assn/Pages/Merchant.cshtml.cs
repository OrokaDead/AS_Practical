using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace _211787P_Practical_Assn.Pages
{
    [Authorize(Roles="Merchant")]
    public class MerchantModel : PageModel
    {

        public void OnGet()
        {
        }
    }
}
