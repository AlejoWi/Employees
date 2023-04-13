using Employees.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employees.Api.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : BaseApiController
    {
        [Route("GetEmployees")]
        [HttpGet]
        public HttpResponseMessage GetEmployees()
        {
            EmployeesBusinessLogic bl = new EmployeesBusinessLogic();
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bl.GetEmployees());
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
            EmployeesBusinessLogic bl = new EmployeesBusinessLogic();
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bl.GetEmployee(id));
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