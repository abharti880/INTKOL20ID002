using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCruiserUserStories.DAO;
using MovieCruiserUserStories.Models;

namespace MovieCruiserUserStories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly DbCon con;
        public MemberController(DbCon _con)
        {
            con = _con;
        }

        [HttpGet("{userName}")]
        public bool Get(string userName,[FromBody] string password)
        {
            var data = con.Member.Find(userName);

            if (data != null && data.password == password)
                return true;

            return false;
        }

        [HttpPost]
        public string Post([FromBody] Member member)
        {
            if (member.password != member.confirmPassword)
                return "Password Mismatch";

            con.Member.Add(member);
            con.SaveChanges();

            return "Successfully Registered";
        }
    }
}