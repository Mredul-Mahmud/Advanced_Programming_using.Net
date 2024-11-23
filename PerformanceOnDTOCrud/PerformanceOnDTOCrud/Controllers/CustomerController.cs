using PerformanceOnDTOCrud.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PerformanceOnDTOCrud.DTOs;

namespace PerformanceOnDTOCrud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        //public ActionResult Index()
        //{
        //    return View();
        //}
        CrudwithDTOEntities2 db = new CrudwithDTOEntities2();

        

        public static Customer Convert(CustomerDTO c)
        {
            return new Customer
            {
                CustomerId = c.CustomerId,
                FullName = c.FirstName + " " + c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                DateJoined = c.DateJoined
            };
        }
        public static CustomerDTO Convert(Customer c)
        {
            // Split FullName into FirstName and LastName
            var names = c.FullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return new CustomerDTO
            {
                CustomerId = c.CustomerId,
                FirstName = names.Length > 0 ? names[0] : "",
                LastName = names.Length > 1 ? names[1] : "",
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                DateJoined = c.DateJoined
            };
        }
        public static List<CustomerDTO> Convert(List<Customer> data)
        {
            var list = new List<CustomerDTO>();
            foreach (var c in data)
            {
                list.Add(Convert(c));
            }
            return list;
        }

        public ActionResult List()
        {
            var data = db.Customers.ToList();
            return View(Convert(data));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CustomerDTO());
        }
        [HttpPost]
        public ActionResult Create(CustomerDTO c)
        {
            if (ModelState.IsValid)
            {
                // Concatenate FirstName and LastName to form FullName
                string fullName = c.FirstName + " " + c.LastName;

                // Map the DTO to the Entity object
                var customer = new Customer
                {
                    FullName = fullName, 
                    Email = c.Email,
                    Phone = c.Phone,
                    Address = c.Address,
                    DateJoined = c.DateJoined
                };

                // Add the new customer to the database
                db.Customers.Add(customer);
                db.SaveChanges();

                TempData["Msg"] = "Customer Created Successfully";
                return RedirectToAction("List");
            }

            return View(c);  
        }
        public ActionResult Details(int id)
        {
            var exobj = db.Customers.Find(id);
            return View(Convert(exobj));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Customers.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        
          public ActionResult Edit(CustomerDTO c)
          {
             if (ModelState.IsValid)
             {
                  var exobj = db.Customers.Find(c.CustomerId);

                  if (exobj != null)
                  {
                      // Update the entity based on the DTO values
                      exobj.FullName = c.FirstName + " " + c.LastName;
                      exobj.Email = c.Email;
                      exobj.Phone = c.Phone;
                      exobj.Address = c.Address;
                      exobj.DateJoined = c.DateJoined;

                      db.SaveChanges();
                      TempData["Msg"] = "Customer Updated Successfully";
                      return RedirectToAction("List");
                  }

                  TempData["ErrorMsg"] = "Customer not found";
                  return RedirectToAction("List");
             }

                return View(c);  // Return the DTO if the model is not valid
            }
    

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = db.Customers.Find(id);
            if (student == null)
            {
                TempData["ErrorMsg"] = "Student not found";
                return RedirectToAction("List");
            }

            return View(student); // Show confirmation view before deleting
        }
        [HttpPost]
        public ActionResult Delete(Customer formObj)
        {
            var student = db.Customers.Find(formObj.CustomerId);
            if (student != null)
            {
                db.Customers.Remove(student);
                db.SaveChanges();
                TempData["Msg"] = "Student deleted successfully";
            }
            else
            {
                TempData["ErrorMsg"] = "Student not found";
            }

            return RedirectToAction("List");
        }
    }
}