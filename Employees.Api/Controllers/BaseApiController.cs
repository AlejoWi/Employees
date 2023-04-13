using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;

namespace Employees.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        private int _transactionCount = 0;
        protected HttpResponseMessage GetHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response;
            try
            {
                response = codeToExecute.Invoke();
            }
            catch (SecurityException ex)
            {
                response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (TimeoutException ex)
            {
                _transactionCount += 1;
                if (_transactionCount == 1)
                {
                    response = request.CreateResponse(HttpStatusCode.RequestTimeout, ex.Message);
                }
                else
                {
                    _transactionCount = 0;
                    response = request.CreateResponse(HttpStatusCode.InternalServerError, "Error de Timeout: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                string detailsToShow = ex.Message;
                response = request.CreateResponse(HttpStatusCode.InternalServerError, detailsToShow);
                response.ReasonPhrase = detailsToShow;
            }

            return response;
        }
    }
}