﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruYum.Models;

namespace TruYum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AnonymousUserController : ControllerBase
    {
        // GET: api/AnonymousUser
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            MenuItemOperation mo = new MenuItemOperation();
            return mo.SelectMenuItems();
        }

        // GET: api/AnonymousUser/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AnonymousUser
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AnonymousUser/5
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
