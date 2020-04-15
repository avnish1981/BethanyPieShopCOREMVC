using BethanyPieShop.EntityFramework;
using BethanyPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Services
{
    public class SqlCategoryData:ICategoryData 
    {
        private readonly AppDbContext _appDb;

        public SqlCategoryData(AppDbContext appDb )
        {
            _appDb = appDb;
           
        }

        public IEnumerable<Category> AllCategories
        {
            get
            {
                return _appDb.Categories.ToList();
            }
        }
    }
}
