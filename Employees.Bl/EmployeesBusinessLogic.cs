using Employees.Bl.Entities;
using Employees.Da;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Bl
{    
    public class EmployeesBusinessLogic
    {
        private ApiConnection _Apiconnection;

        public EmployeesBusinessLogic()
        {
            _Apiconnection = new ApiConnection();
        }

        public JObject GetEmployees()
        {
            string EmployeesString = _Apiconnection.GetEmployees();
            try
            {
                JObject JObj = JObject.Parse(EmployeesString);                
                return CalculateAnualSalary(JObj); ;
            }
            catch
            {
                JObject JObj = new JObject();
                JObj.Add("status", "failed");
                JObj.Add("Error", EmployeesString);

                return JObj;
            }                         
        }

        public JObject GetEmployee(string IdEmployee)
        {
            string EmployeesString = _Apiconnection.GetEmployee(IdEmployee);
            try
            {
                JObject JObj = JObject.Parse(EmployeesString);
                return CalculateAnualSalarySingle(JObj);
            }
            catch
            {
                JObject JObj = new JObject();
                JObj.Add("status", "failed");
                JObj.Add("Error", EmployeesString);

                return JObj;
            }
        }

        private JObject CalculateAnualSalary(JObject JObj)
        {
            var dataArray = (JArray)JObj["data"];
            foreach (var item in dataArray)
            {
                var employee = (JObject)item;
                employee["Employee_anual_salary"] = Convert.ToInt32(employee["employee_salary"]) * 12;
            }

            return JObj;
        }

        private JObject CalculateAnualSalarySingle(JObject JObj)
        {
            var dataObject = (JObject)JObj["data"];
            dataObject["Employee_anual_salary"] = Convert.ToInt32(dataObject["employee_salary"]) * 12;            
            return JObj;
        }

    }
}
