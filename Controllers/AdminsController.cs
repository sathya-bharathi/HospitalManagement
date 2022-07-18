using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Models;
using System.Collections;
using System.Linq;
using System.Net.Mail;
using System.Net;



namespace HospitalManagement.Controllers
{
    public class AdminsController : Controller
    {
        private readonly HMSDBContext _context;

        public AdminsController(HMSDBContext context)
        {
            _context = context;
        }

        public IActionResult DoctorRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoctorRegistration(DoctorRegistration obj)
        {
           _context.DoctorRegistrations.Add(obj);
            _context.SaveChanges();
            var senderEmail = new MailAddress("librarymanagement13@gmail.com", "Sathya");
            var receiverEmail = new MailAddress(obj.EmailId, "Receiver");
            var password = "kigksgbmzemtqrax";
            var sub = "Hello" + obj.Name + "Request Quote";
            var body = "Hello"+obj.Name+"Your User Id is"+obj.Id;
            
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }
            return RedirectToAction("Doctor", "Login");
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admins.ToListAsync());
        }

     
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailId,Name,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

      
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmailId,Name,Password")] Admin admin)
        {
            if (id != admin.EmailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.EmailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

      
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var admin = await _context.Admins.FindAsync(id);
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(string id)
        {
            return _context.Admins.Any(e => e.EmailId == id);
        }
    }
}
