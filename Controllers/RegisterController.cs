using HospitalManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HMSDBContext db;
        private readonly ISession session;
        public RegisterController(HMSDBContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult PatientRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PatientRegistration(Patient obj)
        {
            db.Patients.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Patient","Login");
        }
    }
}
