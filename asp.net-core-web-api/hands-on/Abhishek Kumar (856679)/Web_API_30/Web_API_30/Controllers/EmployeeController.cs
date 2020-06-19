using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Web_API_30.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private List<Employee> list = new List<Employee>()
        {
            new Employee{Id=1,Name="Sujoy"},
            new Employee{Id=2,Name="Pritam"}
        };

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return list;
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return list.FirstOrDefault(p => p.Id == id);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee value)
        {
            list.Add(value);

            return Ok(value);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] Employee value)
        {
            if (id == 0 || id < 0)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent("Naughty");
                

                return response;
            }
            else
            {
                var data = list.FirstOrDefault(p => p.Id == id);
                if(data==null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    response.Content = new StringContent("Naughty");

                    return response;
                }
                else
                {
                    data.Id = value.Id;
                    data.Name = value.Name;
                                       
                }
                        
            }

            var response1 = new HttpResponseMessage(HttpStatusCode.OK);
            response1.Content = new StringContent("Data Updated");

            return response1;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
