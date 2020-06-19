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
    //[Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly DbCon con;
        public CustomerController(DbCon _con)
        {
            con = _con;
        }


        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            var data=con.Movies.ToList();

            List<Movies> list = new List<Movies>();

            foreach(var item in data)
            {
                if (item.Active == true && item.DateOfLaunch < DateTime.Now)
                    list.Add(item);
            }
            return list;
        }
        [HttpGet("{userId}")]
        public Favorites Get(int userId)
        {
            var data = con.WatchList.Where(p=>p.Favorite==true).ToList();
            
            
            string[] array = new string[data.Count()];

            int i = 0;
            foreach(var item in data)
            {
                if(item.CustomerId==userId)
                {
                    array[i++] = item.Title;
                }
            }
            Favorites fav = new Favorites();

            fav.Id = userId;
            fav.Movies = array;
            fav.Count = array.Length;
            


            return fav;


            //List<Favorites> list = new List<Favorites>();
            //foreach (var item in data)
            //{
            //    if (item.Favorite == true && item.CustomerId == userId)
            //    {
            //        //list.Add(item);
            //    }
            //}
            //return list; 
        }


        [HttpPost("{moviId}")]
        public string Post(int moviId,[FromBody] bool isFav)
        {
            var chk = con.WatchList.Where(p=>p.MovieId == moviId).FirstOrDefault();

            if (chk == null)
            {
                var movie = con.Movies.Find(moviId);
                WatchList item = new WatchList();

                item.CustomerId = 1;
                item.MovieId = movie.Id;
                item.Title = movie.Title;
                item.DateOfLaunch = movie.DateOfLaunch;
                item.Genre = movie.Genre;
                item.HasTeaser = movie.HasTeaser;
                item.Favorite = isFav;

                con.WatchList.Add(item);
                con.SaveChanges();
            }
            else
                return "Item Already Exists in Watchlist";
            

            return "Added to Your Watchlist";
        }
        [HttpDelete("{movieId}")]
        public string Delete(int movieId)
        {
            
            var movie = con.WatchList.Where(p=>p.MovieId==movieId).FirstOrDefault();
            if (movie != null)
            {
                con.WatchList.Remove(movie);
                con.SaveChanges();
            }
            else
                return "Movie Doesn't exist in your Watchlist";
            

            return "Movie removed from your Watchlist";
        }
    }
}