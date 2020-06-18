using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruYum.Models;

namespace TruYum.DAO
{
    public class DbCon:DbContext
    {
        public DbCon(DbContextOptions<DbCon> options):base(options)
        {

        }

        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<User> User { get; set; }
    }
}
