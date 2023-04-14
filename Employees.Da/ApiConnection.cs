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
        private static string _UrlApi = "http://dummy.restapiexample.com/api/v1/";
        private static RestClient _Client;
        private static string _Methodemployees = "employees";
        private static string _Methodemployee = "employee/";

        public static string GetEmployee(string IdEmployee)
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

        public static string GetEmployees()
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

        private static string ConsultApiInfo()
        {
            var RestReq = new RestRequest(Method.POST);
            RestReq.AddHeader("Content-Type", "application/json");
            IRestResponse response = _Client.Execute(RestReq);
            return response.Content.ToString();
        }
    }
}
