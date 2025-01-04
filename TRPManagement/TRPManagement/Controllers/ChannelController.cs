using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPManagement.DTOs;
using TRPManagement.EF;

namespace TRPManagement.Controllers
{
    public class ChannelController : Controller
    {
        TRPManagementEntities db = new TRPManagementEntities();
    
        // GET: Channel
        public ActionResult Index()
        {
            return View();
        }


        public static Channel Convert(ChannelDTO c)
        {
            return new Channel
            {
                ChannelId = c.ChannelId,
                ChannelName = c.ChannelName,
                EstablishedYear = c.EstablishedYear,
                Country = c.Country

            };
        }
        public static ChannelDTO Convert(Channel c)
        {
            return new ChannelDTO
            {
                ChannelId = c.ChannelId,
                ChannelName = c.ChannelName,
                EstablishedYear = c.EstablishedYear,
                Country = c.Country
            };
        }
        public static List<ChannelDTO> Convert(List<Channel> data)
        {
            var list = new List<ChannelDTO>();
            foreach (var c in data)
            {
                list.Add(Convert(c));
            }
            return list;

        }

        public ActionResult List()
        {
            var data = db.Channels.ToList();
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Channel());
        }
        [HttpPost]

        public ActionResult Create(ChannelDTO c)

        {
            var existingUser = db.Channels.SingleOrDefault(u => u.ChannelName.Equals(c.ChannelName));
            if (existingUser != null)
            {
                ModelState.AddModelError("ChannelName", "This Name already exists. Please choose a different one.");
                return View(c);
            }
            if (ModelState.IsValid)
            {
                var exobj = new Channel
                {
                    ChannelName = c.ChannelName,
                    EstablishedYear = c.EstablishedYear,
                    Country = c.Country
                };
                //validation
                db.Channels.Add(exobj);
                db.SaveChanges();
                TempData["Msg"] = "Student Created";
                return RedirectToAction("List");
            }
            return View(c);

        }
        public ActionResult Details(int id)
        {
            var exobj = db.Channels.Find(id);
            return View(Convert(exobj));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Channels.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Edit(ChannelDTO c)
        {


            var exobj = db.Channels.Find(c.ChannelId);
            if (exobj != null)
            {
                exobj.ChannelName = c.ChannelName;
                exobj.EstablishedYear = c.EstablishedYear;
                exobj.Country = c.Country;
                db.Entry(exobj).CurrentValues.SetValues(c);
                //Recommended One
                //exobj.Name = formObj.Name;
                //exobj.Cgpa = formObj.Cgpa;


                db.SaveChanges();
                TempData["Msg"] = "Channel Updated";
                return RedirectToAction("List");

            }
            TempData["Msg"] = "Channel Not Updated";
            return RedirectToAction("lisT");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var exobj = db.Channels.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Delete(int Id, string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var exobj = db.Channels.Find(Id);
                db.Channels.Remove(exobj);
                db.SaveChanges();
                TempData["Msg"] = "Channel Deleted Successfully";

            }
            else
            {
                TempData["Msg"] = "Channel not Deleted !!";
            }
            return RedirectToAction("List");
        }





    }
}