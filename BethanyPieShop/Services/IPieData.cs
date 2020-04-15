using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;


namespace BethanyPieShop.Services
{
   public  interface IPieData
    {
        IEnumerable<Pie> AllPie { get;  }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieid);

    }
}
