using ChargeBackCalculation.Models;
using ChargeBackCalculation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChargeBackCalculation.Controllers
{
    public class EmployeeRegistersController : Controller
    {
        private UserLoginDbContext db = new UserLoginDbContext();
        ChargeBackCalculation.Methods.Methods methods = new ChargeBackCalculation.Methods.Methods();

        // Registration for Employee
        public ActionResult EmployeeRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeRegister([Bind(Include = "Id,UserId,FirstName,LastName,DateOfBirth,Gender,PhoneNumber,Address,City,State,ZipCode,Email,UserName,Password,ConfirmPassword,SecretQuestions,Answer,RegisterDate")] EmployeeRegister employeeRegister, string UserRole)
        {
            if (ModelState.IsValid)
            {
                if (UserRole == "Employee")
                {
                    db.EmployeeRegisters.Add(employeeRegister);
                    db.SaveChanges();
                    return RedirectToAction("EmployeeLogin");
                }
            }
            else
            {
                ModelState.AddModelError(" ", "pass the correct user role");
            }
            return View();
        }
        // Employee Login
        public ActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeLogin(string username, string password)
        {
            var user = db.EmployeeRegisters.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid credentials";
            }
            return View();
        }
        // Recovering forgot Employee UserID
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
                        var user = db.EmployeeRegisters.FirstOrDefault(x => x.Answer == userIdRecovery.Answer && x.SecretQuestions == userIdRecovery.SecretQuestions && x.Email == userIdRecovery.Email);
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
        // Setting up new password for employee
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
                    var user = db.EmployeeRegisters.FirstOrDefault(x => x.UserId == passwordReset.UserId && x.SecretQuestions == passwordReset.SecretQuestions && x.Answer == passwordReset.Answer);
                    return RedirectToAction("PasswordUpdate", new { id = user.UserId });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials.");
                    return View();
                }
            }
        }
        // Updating the new employee password in the database
        public ActionResult PasswordUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordUpdate(int id, NewPassword newPassword)
        {
            EmployeeRegister user1 = new EmployeeRegister();
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (newPassword != null)
                {
                    user1 = db.EmployeeRegisters.FirstOrDefault(x => x.UserId==id);
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
