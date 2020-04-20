using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.EntityFramework;
using BethanyPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanyPieShop.Services
{
    public class SqlPieData : IPieData
    {
        private readonly AppBethyDbContext _appDb;

        public SqlPieData(AppBethyDbContext appDb)
        {
            this._appDb = appDb;
        }
        public IEnumerable<Pie> AllPie
        {
            get
            {
               return  _appDb.Pies.Include(c => c.Category);
            }
        }
            

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDb.Pies.Include(c => c.Category).Where(p => p.IsPieOfWeek);
            }
        }
       

        public Pie GetPieById(int pieid)
        {
            return _appDb.Pies.FirstOrDefault(a => a.PieId == pieid);
        }
    }
}
