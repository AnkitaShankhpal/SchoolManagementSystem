using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagementSystem;
using SchoolManagementSystem.Models;
using System.Web.Security;
using System.Web.Helpers;

namespace SchoolManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {

            using (var context = new SchoolSystemDBEntities())
            {
                bool isValid = context.User.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid userName and Password");
                }
              
                return View();
            }

        }

 
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Models.Membership model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new SchoolSystemDBEntities())
                {
                    User user = new User()
                    {
                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Password = model.Password,
                    };
                    
                    context.User.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("Login");

                }
               
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult forgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult forgotPassword(User model)
        {
            using (var context = new SchoolSystemDBEntities())
            {
                context.User.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
    }
}