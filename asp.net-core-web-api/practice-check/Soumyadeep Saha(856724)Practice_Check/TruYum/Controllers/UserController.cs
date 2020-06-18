using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruYum.DAO;
using TruYum.Models;

namespace TruYum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbCon con;
        public UserController(DbCon _con)
        {
            con = _con;
        }
        [HttpGet("{id}")]
        public bool Get(int id,[FromBody]string password)
        {
            var data = con.User.ToList();
            foreach(var cred in data)
            {
                if (cred.userId == id && cred.password == password)
                    return true;                
            }
            return false;
        }
        [HttpPost]
        public string Post([FromBody]User cred)
        {
            con.User.Add(cred);
            con.SaveChanges();

            return "Successfully Registered";
        }
    }
}