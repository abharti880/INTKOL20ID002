using Microsoft.EntityFrameworkCore;
using MovieCruiserUserStories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCruiserUserStories.DAO
{
    public class DbCon:DbContext
    {
        public DbCon(DbContextOptions<DbCon> options) : base(options)
        {

        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<WatchList> WatchList { get; set; }
        public DbSet<Member> Member { get; set; }
       
    }
}
