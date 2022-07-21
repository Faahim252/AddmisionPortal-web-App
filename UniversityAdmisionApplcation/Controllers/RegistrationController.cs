using Microsoft.AspNetCore.Mvc;

namespace UniversityAdmisionApplcation.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
