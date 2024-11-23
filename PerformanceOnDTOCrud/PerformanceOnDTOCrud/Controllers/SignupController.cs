using PerformanceOnDTOCrud.EF;
using PerformanceOnDTOCrud.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanceOnDTOCrud.Controllers
{
    public class SignupController : Controller
    {
        CrudwithDTOEntities2 db = new CrudwithDTOEntities2();
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View(new SignupDTO());
        }

        [HttpPost]
        public ActionResult Signup(SignupDTO user)
        {
            //if (ModelState.IsValid)
            //{
                // Check if the email already exists
                var existingUser = db.AllAuths.SingleOrDefault(u => u.Email.Equals(user.Email));
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email already exists. Please choose a different one.");
                    return View(user);
                }

                // Convert DTO to entity and save
                var newUser = new AllAuth
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    Role = string.IsNullOrEmpty(user.Role) ? "User" : user.Role
                };

                db.AllAuths.Add(newUser);
                db.SaveChanges();

                return RedirectToAction("List", "Customer"); // Redirect after successful signup

            //}
            //return View(user);
        }
    }
}