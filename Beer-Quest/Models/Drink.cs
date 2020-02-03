using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer_Quest.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholPercent { get; set; }
        public int DrinkTypeId { get; set; }
        public int BreweryId { get; set; }
        public bool HouseFav { get; set; }
        public Brewery Brewery { get; set; }
        public DrinkType DrinkType { get; set; }
    }
}
