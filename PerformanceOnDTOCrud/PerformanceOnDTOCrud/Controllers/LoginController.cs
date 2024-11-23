using PerformanceOnDTOCrud.DTOs;
using PerformanceOnDTOCrud.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanceOnDTOCrud.Controllers
{
    public class LoginController : Controller
    {
        CrudwithDTOEntities2 db = new CrudwithDTOEntities2();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public ActionResult Login(LoginDTO log)
        {
            //
            var user = (from u in db.AllAuths
                        where u.Email.Equals(log.Email) &&
                        u.Password.Equals(log.Password)
                        select u).SingleOrDefault();
            if (user != null)
            {
                Session["user"] = user; //boxing
                return RedirectToAction("List", "Customer");
            }
            TempData["Msg"] = "User not found";
            return View();
        }

    }
}