using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChargeBackCalculation.Models;

namespace ChargeBackCalculation.Controllers
{
    public class AdminRegistersController : Controller
    {
        private UserLoginDbContext db = new UserLoginDbContext();

        // Registration for admin
        public ActionResult AdminRegister()
        {
            return View();
        }     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegister([Bind(Include = "Id,UserId,FirstName,LastName,DateOfBirth,Gender,PhoneNumber,Address,City,State,ZipCode,UserName,Password,ConfirmPassword,RegisterDate")] AdminRegister adminRegister, string UserRole)
        {
            if (ModelState.IsValid)
            {
                if (UserRole == "Admin")
                {
                    db.AdminRegisters.Add(adminRegister);
                    db.SaveChanges();
                    return RedirectToAction("AdminLogin");
                }
            }
            else
            {
                ModelState.AddModelError(" ", "pass the correct user role");
            }
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(string username, string password)
        {
            var user = db.AdminRegisters.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (user != null)
            {

                return RedirectToAction("Index", "Admins");
            }
            else
            {
                ModelState.AddModelError(" ","Invalid credentials");
            }

            return View();
        }
    }
}
