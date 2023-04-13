using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Employees.Web.Controllers
{    
    public class EmployeesController : Controller
    {
        private HttpClient _client;
        private string _Url = ConfigurationManager.AppSettings["WebApiUrl"];
        // GET: Employees
        public async Task<ActionResult> Index()
        {
            List<Models.EmployeesModel> ListEmployees = new List<Models.EmployeesModel>();            
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_Url);
            HttpResponseMessage response = await _client.GetAsync("GetEmployees");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject JObj = JObject.Parse(responseBody);
                if ((string)JObj.SelectToken("$.status") == "success")
                {
                    ListEmployees = MapJObjToModel(JObj);
                }
            }            
            return View("Index", ListEmployees);
        }

        [HttpPost]
        public async Task<ActionResult> GetEmployeeById(string IdEmployee)
        {
            HttpResponseMessage response = null;
            List<Models.EmployeesModel> ListEmployees = new List<Models.EmployeesModel>();            
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_Url);
            if(string.IsNullOrEmpty(IdEmployee))
            {
                response = await _client.GetAsync("GetEmployees");
            }
            else
            {
                response = await _client.GetAsync(string.Format("GetEmployee/?id={0}", IdEmployee));
            }
            
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject JObj = JObject.Parse(responseBody);
                if((string)JObj.SelectToken("$.status") == "success")
                {
                    if (string.IsNullOrEmpty(IdEmployee)) 
                    {
                        ListEmployees = MapJObjToModel(JObj);
                    }
                    else
                    {
                        ListEmployees = MapJObjToModelSingle(JObj);
                    }
                        
                }                
            }
            return View("Index", ListEmployees);
        }

        private List<Models.EmployeesModel> MapJObjToModel(JObject JObj)
        {
            List<Models.EmployeesModel> ListEmployees = new List<Models.EmployeesModel>();
            JArray employeesArray = (JArray)JObj.SelectToken("$.data");
            foreach (JObject employeeObject in employeesArray)
            {
                Models.EmployeesModel employee = employeeObject.ToObject<Models.EmployeesModel>();
                ListEmployees.Add(employee);
            }
            return ListEmployees;
        }

        private List<Models.EmployeesModel> MapJObjToModelSingle(JObject JObj)
        {
            List<Models.EmployeesModel> ListEmployees = new List<Models.EmployeesModel>();
            JObject employeeObj = (JObject)JObj.SelectToken("$.data");
            Models.EmployeesModel employee = employeeObj.ToObject<Models.EmployeesModel>();
            ListEmployees.Add(employee);
            return ListEmployees;
        }
    }
}
