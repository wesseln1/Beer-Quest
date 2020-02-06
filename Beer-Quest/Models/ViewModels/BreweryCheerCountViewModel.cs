using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer_Quest.Models.ViewModels
{
    public class BreweryCheerCountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Phone { get; set; }
        public int CheersCount { get; set; }
        public int CommentCount { get; set; }
        public string UserId { get; set; }
        public List<Drink> Drinks { get; set; }
        public List<Comment> Comments { get; set; }
        public string ImagePath { get; set; }
    }
}
