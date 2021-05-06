using ChargeBackCalculation.Models;
using ChargeBackCalculation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChargeBackCalculation.Controllers
{
    public class CustomerRegistersController : Controller
    {
        ChargeBackCalculation.Methods.Methods methods = new ChargeBackCalculation.Methods.Methods();
        private UserLoginDbContext db = new UserLoginDbContext();
        // Registration for Customer
        public ActionResult CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerRegister([Bind(Include = "Id,UserId,FirstName,LastName,DateOfBirth,Gender,PhoneNumber,Address,City,State,ZipCode,UserName,Password,ConfirmPassword,SecretQuestions,Answer,RegisterDate")] CustomerRegister customerRegister, string UserRole)
        {
            if (ModelState.IsValid)
            {
                if (UserRole == "Customer")
                {
                    db.CustomerRegisters.Add(customerRegister);
                    db.SaveChanges();
                    return RedirectToAction("CustomerLogin");
                }
            }
            else
            {
                ModelState.AddModelError(" ", "pass the correct user role");
            }
            return View();
        }
        // Customer Login
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerLogin(string username, string password)
        {
            var user = db.CustomerRegisters.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction("Index1", "ComplaintRegisters");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid credentials";
                //ModelState.AddModelError(" ", "Invalid credentials");
            }
            return View();
        }
        // Recovering forgot Customer UserID
        public ActionResult RecoveryUserId()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecoveryUserId(UserIdRecovery userIdRecovery)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                using (UserLoginDbContext db = new UserLoginDbContext())
                {
                    if (userIdRecovery != null)
                    {
                        var user = db.CustomerRegisters.FirstOrDefault(x => x.Answer == userIdRecovery.Answer && x.SecretQuestions == userIdRecovery.SecretQuestions && x.Email == userIdRecovery.Email);
                        ViewBag.msg = "Your User Id is:" + user.UserId;
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Credentials.");
                        return View();
                    }
                }
            }
        }
        // Setting up new password for customer
        public ActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordReset(PasswordReset passwordReset)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (passwordReset != null)
                {
                    UserLoginDbContext db = new UserLoginDbContext();
                    var user = db.CustomerRegisters.FirstOrDefault(x => x.UserId == passwordReset.UserId && x.SecretQuestions == passwordReset.SecretQuestions && x.Answer == passwordReset.Answer);
                    return RedirectToAction("PasswordUpdate", new { id = user.UserId });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials.");
                    return View();
                }
            }
        }
        // Updating the new customer password in the database
        public ActionResult PasswordUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordUpdate(int id, NewPassword newPassword)
        {
            CustomerRegister user1 = new CustomerRegister();
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (newPassword != null)
                {
                    user1 = db.CustomerRegisters.FirstOrDefault(x => x.UserId == id);
                    user1.Password = newPassword.Password;
                    user1.ConfirmPassword = newPassword.ConfirmPassword;
                    methods.Save(db);
                    ViewBag.msg = "Password Reset Successfully";
                    return View();
                }
                ModelState.AddModelError("", "Invalid Credentials.");
                return View();
            }
        }
    }
}