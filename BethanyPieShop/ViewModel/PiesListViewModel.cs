using BethanyPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.ViewModel
{
    public class PiesListViewModel
    {
        public IEnumerable <Pie> Pies { get; set; }
        public string Currency { get; set; }
    }
}
