using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace Employees.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetEmployee()
        {
            JArray expected = new JArray();
            JObject Obj = GetEmployeeData();
            expected.Add((JObject)Obj["data"]);            
            JArray result = Bl.EmployeesBusinessLogic.GetEmployee("1");
            string jsonRes = result.ToString(Newtonsoft.Json.Formatting.None);
            string jsonspec = expected.ToString(Newtonsoft.Json.Formatting.None);
            Assert.AreEqual(jsonRes, jsonspec);
        }       

        private JObject GetEmployeeData()
        {
            string JsonEmployeesInfo = @"
{
    ""status"": ""success"",
    ""data"": {
        ""id"": 1,
        ""employee_name"": ""Tiger Nixon"",
        ""employee_salary"": 320800,
        ""employee_age"": 61,
        ""profile_image"": """",
        ""Employee_anual_salary"": 3849600
    },
    ""message"": ""Successfully! Record has been fetched.""
}
";
            JObject Obj = JObject.Parse(JsonEmployeesInfo);
            return Obj;
        }        
    }
}
