using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCruiserUserStories.Models
{
    public class Favorites
    {
        [Key]
        public int Id { get; set; }
        public string[] Movies { get; set; }
        public int Count { get; set; }
    }
}
