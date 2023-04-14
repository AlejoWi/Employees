using Employees.Da;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Bl
{    
    public static class EmployeesBusinessLogic
    {                
        public static JArray GetEmployees()
        {            
            string EmployeesString = ApiConnection.GetEmployees();
            try
            {
                JObject JObj = CalculateAnualSalary(JObject.Parse(EmployeesString));                              
                return (JArray)JObj["data"];
            }
            catch
            {
                JArray JObj = new JArray();                

                return JObj;
            }                         
        }

        public static JArray GetEmployee(string IdEmployee)
        {            
            string EmployeesString = ApiConnection.GetEmployee(IdEmployee);
            try
            {
                JObject JObj = CalculateAnualSalarySingle(JObject.Parse(EmployeesString));
                JArray JArr = new JArray();
                JArr.Add((JObject)JObj["data"]);
                return JArr;
            }
            catch
            {
                JArray JObj = new JArray();
                return JObj;
            }
        }

        public static  JObject CalculateAnualSalary(JObject JObj)
        {
            var dataArray = (JArray)JObj["data"];
            foreach (var item in dataArray)
            {
                var employee = (JObject)item;
                employee["Employee_anual_salary"] = Convert.ToInt32(employee["employee_salary"]) * 12;
            }

            return JObj;
        }

        public static JObject CalculateAnualSalarySingle(JObject JObj)
        {
            var dataObject = (JObject)JObj["data"];
            dataObject["Employee_anual_salary"] = Convert.ToInt32(dataObject["employee_salary"]) * 12;            
            return JObj;
        }

    }
}
