using Microsoft.AspNetCore.Mvc;

namespace Project_Mvc.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name","Ahmed Atef Badawy");
            HttpContext.Session.SetInt32("Phone Number",01005536725);
            return Content("Saved Data");
        }
        public IActionResult GetSession()
        {
            string? name = HttpContext.Session.GetString("Name");
            int? PhoneNumber = HttpContext.Session.GetInt32("Phone Number").Value;
            return Content($"name = {name}  →→→→→  Phone Number {PhoneNumber}");
        }
    }
}
