using Microsoft.AspNetCore.Mvc;

namespace UniversityAdmisionApplcation.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Applications()
        {
            return View();
        }

        public IActionResult Process()
        {
            return View();
        }
    }
}
