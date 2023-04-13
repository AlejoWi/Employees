using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;
using System.Web.Script.Serialization;
using RestSharp;

namespace Employees.Da
{
    public class ApiConnection
    {
        private string _UrlApi;
        private RestClient _Client;
        private string _Methodemployees = "employees";
        private string _Methodemployee = "employee/";
        public ApiConnection()
        {
            _UrlApi = ConfigurationManager.AppSettings["ApiEmployee"];            
        }

        public string GetEmployee(string IdEmployee)
        {
            try
            {

                _Client = new RestClient(_UrlApi + _Methodemployee + IdEmployee);
                return ConsultApiInfo();                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetEmployees()
        {
            try
            {                
                _Client = new RestClient(_UrlApi + _Methodemployees);
                return ConsultApiInfo();


            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string ConsultApiInfo()
        {
            var RestReq = new RestRequest(Method.POST);
            RestReq.AddHeader("Content-Type", "application/json");
            IRestResponse response = _Client.Execute(RestReq);
            return response.Content.ToString();
        }
    }
}
