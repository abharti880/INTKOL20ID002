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
    public class AnonymousController : ControllerBase
    {
        private readonly DbCon con;
        public AnonymousController(DbCon _con)
        {
            con = _con;
        }
        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            return con.Movies.ToList();
        }
    }
}