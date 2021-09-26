using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Models
{
    public class Beer : Entity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
    }
}
