using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCruiserUserStories.DAO;
using MovieCruiserUserStories.Models;

namespace MovieCruiserUserStories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly DbCon con;
        public AdminController(DbCon _con)
        {
            con = _con;
        }


        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            return con.Movies.ToList();
        }


        [HttpPut("{id}")]
        public string Put(int id,[FromBody]Movies movie)
        {
            var data = con.Movies.Find(id);
            if (data != null)
            {
                data.Id = movie.Id;
                data.Title = movie.Title;
                data.BoxOffice = movie.BoxOffice;
                data.Active = movie.Active;
                data.DateOfLaunch = movie.DateOfLaunch;
                data.Genre = movie.Genre;
                data.HasTeaser = movie.HasTeaser;
                //data.Favorite = movie.Favorite;

                con.SaveChanges();
            }
            else
                return "Id is not in the Database";

            return "Movie Updated";
            
        }
    }
}