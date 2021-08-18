using CandyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.ViewModels
{
    public class CandyListVM
    {
        public IEnumerable<Candy> Candies { get; set; }
        public string currentCategory { get; set; }
    }
}
