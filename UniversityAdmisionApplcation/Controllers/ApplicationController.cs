using Microsoft.AspNetCore.Mvc;
using UniversityAdmisionApplcation.Datebases;
using UniversityAdmisionApplcation.Models;

namespace UniversityAdmisionApplcation.Controllers
{
    public class ApplicationController : Controller
    {

        private readonly ApplicationDbContex _contex;

        public ApplicationController (ApplicationDbContex contex)
        {
          this._contex = contex;
        }
        public IActionResult Applications()
        {

            var reg = _contex.Registration.ToList();

            return View();
        }

        public IActionResult Process()
        {
            return View();
        }

        public IActionResult Addminoff()
        {

            List<AdmissionOfficer> AdmissionOff = (from AdmissionOfficer in this._contex.AdmissionOff.Take(4) select AdmissionOfficer).ToList();
               return View(AdmissionOff);
        }

        public ActionResult Delete(int id)
        {
            var product = _contex.AdmissionOff.Find(id);
            _contex.AdmissionOff.Remove(product);
            _contex.SaveChanges();
            return RedirectToAction("Addminoff");
        }

    }
}
