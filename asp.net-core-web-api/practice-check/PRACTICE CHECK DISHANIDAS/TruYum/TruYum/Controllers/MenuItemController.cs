using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruYum.Models;

namespace TruYum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        // GET: api/MenuItem
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            MenuItemOperation mo = new MenuItemOperation();
            return mo.SelectMenuItems();
        }

        // GET: api/MenuItem/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MenuItem
        [HttpPost]
        public string Post([FromBody] MenuItem item)
        {
            MenuItemOperation mo = new MenuItemOperation();
            mo.InsertMenuItem(item);
            return "Successfully Inserted";
        }

        // PUT: api/MenuItem/5
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
