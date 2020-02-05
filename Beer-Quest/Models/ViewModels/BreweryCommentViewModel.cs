using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer_Quest.Models.ViewModels
{
    public class BreweryCommentViewModel
    {
        public Brewery Brewery { get; set; }
        public List<Comment> Comments {get; set;}
        public string UserComment { get; set; }
    }
}
