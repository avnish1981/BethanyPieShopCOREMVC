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
        private readonly AppBethyDbContext _appDb;

        public SqlCategoryData(AppBethyDbContext appDb )
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
