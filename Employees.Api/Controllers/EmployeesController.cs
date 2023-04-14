using Employees.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Employees.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Employees")]
    public class EmployeesController : BaseApiController
    {
        [Route("GetEmployees")]
        [HttpGet]
        public HttpResponseMessage GetEmployees()
        {            
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, EmployeesBusinessLogic.GetEmployees());
            }
            catch (Exception eException)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(eException.Message)
                });
            }
        }

        [Route("GetEmployee")]
        [HttpGet]
        public HttpResponseMessage GetEmployee(string id)
        {            
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, EmployeesBusinessLogic.GetEmployee(id));
            }
            catch (Exception eException)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(eException.Message)
                });
            }
        }
    }


}