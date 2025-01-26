using System;
using ApiCF.EF.Tables;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCF.Controllers
{
    public class StudentController : ApiController
    {
        Context db = new Context();
        [HttpGet]
        [Route("api/students/getall")]
        public HttpResponseMessage GetAll()
        {
            var data = db.Students.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/students/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = db.Students.Find(id);
            if(data !=null)
                return Request.CreateResponse(HttpStatusCode.OK,data);
            else return Request.CreateResponse(HttpStatusCode.NotFound,data);
        }
        [HttpPost]
        [Route("api/students/create")]
        public HttpResponseMessage Create(Students c)
        {
            db.Students.Add(c);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, c);
        }
    }
}
