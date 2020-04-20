using BethanyPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.ViewModel
{
    public class HomeViewModel
    {
       public IEnumerable<Pie> PiesOftheweek { get; set; }
    }
}
