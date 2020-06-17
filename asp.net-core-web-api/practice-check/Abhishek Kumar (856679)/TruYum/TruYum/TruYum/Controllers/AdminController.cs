using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TruYum.DAO;
using TruYum.Models;


namespace TruYum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        private readonly DbCon con;

        public AdminController(DbCon _con)
        {
            con = _con;
        }
        // GET: api/Admin
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            Category cat;
            
            List<MenuItem> list = new List<MenuItem>();

            var menu = con.MenuItem.ToList();

            
            
            
            foreach (var x in menu)
            {

                    cat = new Category();

                    if (x.categoryId == 1)
                    {
                        
                        cat.Id = x.categoryId;
                        cat.Name = "Starter";
                        
                    }
                    else if (x.categoryId == 2)
                    {
                        
                        cat.Id = x.categoryId;
                        cat.Name = "Main Course";
                        
                    }
                    else if (x.categoryId == 3)
                    {
                        
                        cat.Id = x.categoryId;
                        cat.Name = "Drinks";
                        
                    }
                    else if (x.categoryId == 4)
                    {
                        
                        cat.Id = x.categoryId;
                        cat.Name = "Desert";
                        
                    }
                    x.Category = cat;
                    list.Add(x);
            }

            return list;
        }

        

        

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] MenuItem value)
        {
            //Category category;
            var item = con.MenuItem.Find(id);

            if (item != null)
            {
                //category = new Category();
               // Category data = new Category();
                
                //data = con.Category.Find(value.categoryId);
                

                item.Id = value.Id;
                item.Name = value.Name;
                item.Price = value.Price;
                item.freeDelivery = value.freeDelivery;
                item.Active = value.Active;
                item.DateOfLaunch = value.DateOfLaunch;
                item.categoryId = value.categoryId;
                //item.Category = data;
            }

            con.SaveChanges();

            return "Data Updated";
        }

        
    }
}
