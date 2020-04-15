using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;

namespace BethanyPieShop.Services
{
    public class ClsMockPieRepository : IPieData
    {
        private readonly ICategoryData _CategoryData = new ClsMockCategoryRepository();
        List<Pie> pies = new List<Pie>()
        {
            new Pie{PieId=1,Name="Strabary pie",Price=10.19M,ShortDescription="This is strabary pie",AlleryInformation="Stabary Pie",LongDescription="Strabary Pie of the week"},
            new Pie{PieId=2,Name="Cheese pie",Price=15.29M,ShortDescription="This is cheese pie",AlleryInformation="cheese Pie",LongDescription="cheese Pie of the week"},
            new Pie{PieId=3,Name="BlueBarry pie",Price=10.19M,ShortDescription="This is bluebarry pie",AlleryInformation="bluebarry Pie",LongDescription="bluebarry Pie of the week"}

        };

        public IEnumerable<Pie> AllPie => pies;

        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public Pie GetPieById(int pieid)
        {
            return pies.FirstOrDefault(a => a.PieId == pieid);
        }
    }
}
