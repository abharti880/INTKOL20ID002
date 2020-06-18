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
    public class MoviesController : ControllerBase
    {
        private readonly DbCon con;

        public MoviesController(DbCon _con)
        {
            con = _con;
        }



        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            return con.Movies.ToList();
        }
        [HttpPost]
        public string Post([FromBody] Movies movie)
        {
            con.Movies.Add(movie);
            con.SaveChanges();
            return "Movie Added to Database";
        }
    }
}