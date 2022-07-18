using HospitalManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly HMSDBContext db;
        private readonly ISession session;
        public LoginController(HMSDBContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Admin(Admin obj)
        {
            if (obj.EmailId=="sathyabharathidevaraj@gmail.com" && obj.Password == "Sathya@123")
            {
                return RedirectToAction("Index", "Admins");// Admin Panel should come
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Admin", "Login");
        }
        [HttpGet]
        public IActionResult Doctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Doctor(Doctor obj)
        {
            var result = (from i in db.Doctors
                          where i.Id == obj.Id && i.Password == obj.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("Id", result.Id.ToString());
                return RedirectToAction("Index", "Doctors");
            }
            else
                return View();
        }
        public IActionResult DLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Doctor", "Login");
        }
        [HttpGet]
        public IActionResult Patient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Patient(Patient obj)
        {
            var result = (from i in db.Patients
                          where i.Id == obj.Id && i.Password == obj.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("Id", result.Id.ToString());
                return RedirectToAction("Index", "Patients");
            }
            else
                return View();
        }
        public IActionResult PLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Patient", "Login");
        }
    }
}
