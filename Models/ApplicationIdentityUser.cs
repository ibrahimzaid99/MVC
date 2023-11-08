using Microsoft.AspNetCore.Identity;

namespace Project_Mvc.Models
{
    public class ApplicationIdentityUser:IdentityUser
    {
        string adress { get; set; }
    }
}
