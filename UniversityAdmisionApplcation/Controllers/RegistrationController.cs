using Microsoft.AspNetCore.Mvc;
using UniversityAdmisionApplcation.Datebases;
using UniversityAdmisionApplcation.Models;
using UniversityAdmisionApplcation.Sms_service;

namespace UniversityAdmisionApplcation.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly ApplicationDbContex _contex;

        public RegistrationController(ApplicationDbContex contex)
        {
            _contex = contex;
        }
        public IActionResult Register()
        {
           ViewBag.Faculties = _contex.Faculty.ToList();
           ViewBag.EducationLevels = _contex.EducationLevel.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Register(Registration obj)
        {
            obj.Role = "Student";
            _contex.Registration.Add(obj);
            var result = _contex.SaveChanges();
            if (result > 0)
            {
                var ob = new API();
                var res = ob.SendSMS(obj.MobileNo, "waad ku Mahadsantahay Codsigaaga waxaan kuugu adeegi doonaa si deg deg ah insha aalah");
                TempData["ErrorMasegge"] = "Success";
            }
            else
            {
                TempData["ErrorMasegge"] = "error";
            }
            ViewBag.Faculties = _contex.Faculty.ToList();
            ViewBag.EducationLevels = _contex.EducationLevel.ToList();
            return View();
        }
    }
}
