using Microsoft.AspNetCore.Mvc;

namespace UniversityAdmisionApplcation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Sign()
        {
            return View();
        }

        public IActionResult Forget()
        {
            return View();
        }
    }
}
