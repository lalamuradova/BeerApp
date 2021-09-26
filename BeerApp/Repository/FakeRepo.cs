using BeerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Repository
{
    public class FakeRepo
    {
        public List<Beer> GetAll()
        {
            return new List<Beer>
            {
                 new Beer
                {
                    ImagePath = @"../Images/beer4.jpg",
                    Name = "Philsnerurq",
                    Price = "7.50",
                    Volume = "1.5"
                },
             new Beer
                {
                    ImagePath = @"../Images/heiken.jpg",
                    Name = "Heiken",
                    Price = "8",
                    Volume = "1.8"
                },
              new Beer
                {
                    ImagePath = @"../Images/beer.jpg",
                    Name = "CalsBerg",
                    Price = "9.50",
                    Volume = "2"
                },
            };
        }
    }
}
