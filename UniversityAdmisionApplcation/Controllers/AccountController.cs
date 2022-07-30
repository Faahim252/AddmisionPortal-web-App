using Microsoft.AspNetCore.Mvc;
using UniversityAdmisionApplcation.Datebases;
using UniversityAdmisionApplcation.Models;

namespace UniversityAdmisionApplcation.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContex _contex;
        public AccountController(ApplicationDbContex contex)
        {
            _contex = contex;
        }
        public IActionResult Sign()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sign(Login lg)
        {
            var student_result = _contex.Registration.Where(x => x.Password == lg.Password && x.UserName == lg.UserName).ToList();
            var admission_result = _contex.AdmissionOff.Where(x => x.Password == lg.Password && x.UserName == lg.UserName).ToList();
            if (student_result.Count > 0)
            {
                return RedirectToAction("DashboardPage", "Dashboard");
            }
            else if (student_result.Count > 0)
            {

            }
            TempData["Masegge"] = "Error";
            return View();
        }

        public IActionResult Forget()
        {
            return View();
        }
    }
}
