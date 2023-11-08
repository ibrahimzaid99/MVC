using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Mvc.Filters;
namespace Project_Mvc.Controllers
{
    public class FilterController : Controller
    {
        [HandelError]
        [Authorize]
        public IActionResult Index()
        {
            throw new Exception("ecxeption");
            return View();
        }
    }
}
