using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandsOn27.Models;
using HandsOn27.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Internal;

namespace HandsOn27.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1,Name="Prithwi",Salary=20000,Permanent=true},
            new Employee{Id=2,Name="Soumyadeep",Salary=20000,Permanent=true},
            new Employee{Id=3,Name="Abhishek",Salary=20000,Permanent=true}
        };
        // GET: api/Employee
        [CustomAuthFilter]
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {    
            return employees;   
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
