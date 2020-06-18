using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    [AllowAnonymous]
    public class AnonymousUserController : ControllerBase
    {
        private readonly DbCon con;       

        public AnonymousUserController(DbCon _con)
        {
            con = _con;
        }
        // GET: api/AnonymousUser
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            Category cat;
            List<MenuItem> list = new List<MenuItem>();
            
            var menu= con.MenuItem.ToList();
            
            foreach(var x in menu)
            {
                if(x.categoryId==1)
                {
                    cat = new Category();
                    cat.Id = x.categoryId;
                    cat.Name = "Starter";
                    x.Category = cat;
                }
                else if(x.categoryId==2)
                {
                    cat = new Category();
                    cat.Id = x.categoryId;
                    cat.Name = "Main Course";
                    x.Category = cat;
                }
                else if(x.categoryId==3)
                {
                    cat = new Category();
                    cat.Id = x.categoryId;
                    cat.Name = "Drinks";
                    x.Category = cat;
                }
                else if(x.categoryId==4)
                {
                    cat = new Category();
                    cat.Id = x.categoryId;
                    cat.Name = "Desert";
                    x.Category = cat;
                }
                list.Add(x);
            }

            return list;
        }

        
    }
}
