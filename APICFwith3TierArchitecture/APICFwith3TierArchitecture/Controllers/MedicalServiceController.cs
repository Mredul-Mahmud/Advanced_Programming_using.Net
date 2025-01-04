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
    public class MedicalServiceController : ApiController
    {
        [HttpGet]
        [Route("api/services/all")]
        public HttpResponseMessage Get()
        {
            var data = MedicalServiceService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/services/create")]
        public HttpResponseMessage Create (MedicalServiceDTO m)
        {
            MedicalServiceService.Create(m);
            return Request.CreateResponse(HttpStatusCode.OK, "New Medical Service Information Created Successfully.");
        }
        [HttpPut]
        [Route("api/services/update")]
        public HttpResponseMessage Update(MedicalServiceDTO m)
        {
            MedicalServiceService.Update(m);
            return Request.CreateResponse(HttpStatusCode.OK, "Medical Service Information Updated Successfully.");
        }

        [HttpDelete]
        [Route("api/services/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            MedicalServiceService.Delete(id); 
            return Request.CreateResponse(HttpStatusCode.OK, "Medical Service Information Deleted Successfully.");
        }

    }
}
