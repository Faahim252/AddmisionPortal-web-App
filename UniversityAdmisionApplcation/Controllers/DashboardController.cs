using Microsoft.AspNetCore.Mvc;

namespace UniversityAdmisionApplcation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult DashboardPage()
        {
            return View();
        }


        public IActionResult Product()
        {
            return View();
        }
    }
}
