using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruYum.DAO;
using TruYum.Models;

namespace TruYum.Controllers
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
        public IEnumerable<MenuItem> Get()
        {
            var menu = con.MenuItem.ToList();
            List<MenuItem> list = new List<MenuItem>();
            foreach (var x in menu)
            {
                if (x.Active == true && x.DateOfLaunch < DateTime.Now)
                {
                    list.Add(x);
                }
            }
            return list;

        }


        [HttpGet("{UserId}")]
        public IEnumerable<Cart> Get(int UserId)
        {
            var list = con.Cart.ToList();
            List<Cart> cartItem = new List<Cart>();
            foreach(var data in list)
            {
                if(data.userId==UserId)                
                    cartItem.Add(data);                
            }
            return cartItem;            // Total Price is Not included
        }

        [HttpPost]
        public string Post([FromBody] Cart item)
        {
            
            con.Cart.Add(item);
            con.SaveChanges();

            return "Added to Cart";
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var item = con.Cart.Find(id);
            con.Cart.Remove(item);
            con.SaveChanges();

            return "Removed from Cart";
        }
    }
}