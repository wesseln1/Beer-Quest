using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Beer_Quest.Models
{
    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Phone { get; set; }
        public  int CheersCount { get; set; }
        public string UserId { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }
        public ApplicationUser User { get; set; }
        public List<Cheer> Cheers { get; set; } 
        public List<Comment> Comments { get; set; }
    }
}
