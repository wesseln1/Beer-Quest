using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer_Quest.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int BreweryId { get; set; }
        public string UserId { get; set; }
    }
}
