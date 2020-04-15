using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;

namespace BethanyPieShop.Services
{
    public class ClsMockCategoryRepository : ICategoryData
    {
        List<Category> categories = new List<Category>()
        {
          new Category{CategoryId=1,CategoryName="Fruit pie" , Description="All -Fruits" },
          new Category{CategoryId=2,CategoryName="Cheese cake",Description="Cheesy cake"},
          new Category{CategoryId=3,CategoryName="Seasonal cake",Description="This is seasonal cake"}
        };

        public IEnumerable<Category> AllCategories => categories;
    }
}
