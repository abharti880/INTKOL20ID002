using System;
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
    //[Authorize(Roles ="Customer")]
    public class CustomerController : ControllerBase
    {
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            MenuItemOperation mo = new MenuItemOperation();
            List<MenuItem> menuItems = mo.SelectMenuItems();
            IEnumerable<MenuItem> filtered = from item in menuItems where item.Active == true && (DateTime.Compare(item.DateofLaunch,DateTime.Now)<0) select item;
            return filtered;
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public IEnumerable<MenuItem> Get(int id)
        {
            User user = new User
            {
                Id = id
            };
            CartOperation co = new CartOperation();
            return co.GetCartItems(user);
        }

        // POST: api/Customer
        [HttpPost]
        public string Post([FromBody] Cart cart)
        {
            CartOperation co = new CartOperation();
            return co.AddToCart(cart);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{ItemId}")]
        public string Delete(int ItemId)
        {
            CartOperation co = new CartOperation();
            return co.DeleteFromCart(ItemId);
        }
    }
}
