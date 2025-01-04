using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICFwith3TierArchitecture.Controllers
{
    public class PatientController : ApiController
    {
        [HttpGet]
        [Route("api/patients/all")]
        public HttpResponseMessage Get()
        {
            var data = PatientService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/patients/create")]
        public HttpResponseMessage Create(PatientDTO p)
        {
            PatientService.Create(p);
            return Request.CreateResponse(HttpStatusCode.OK, "New Patient Information Created Successfully.");
        }
        [HttpPut]
        [Route("api/patients/update")]
        public HttpResponseMessage Update(PatientDTO p)
        {
            PatientService.Update(p);
            return Request.CreateResponse(HttpStatusCode.OK, "Patient Information Updated Successfully.");
        }

        [HttpDelete]
        [Route("api/patients/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            PatientService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Patient Information Deleted Successfully.");
        }
    }
}
