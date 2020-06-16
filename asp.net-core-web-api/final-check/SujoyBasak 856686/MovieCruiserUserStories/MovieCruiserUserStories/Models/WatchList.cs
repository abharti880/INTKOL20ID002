using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCruiserUserStories.Models
{
    public class WatchList
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfLaunch { get; set; }
        public string Genre { get; set; }
        public bool HasTeaser { get; set; }
        public bool Favorite { get; set; }

    }
}
