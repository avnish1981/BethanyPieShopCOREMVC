using BethanyPieShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoryData _category;

        public CategoryMenu(ICategoryData category)
        {
            this._category = category;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _category.AllCategories.OrderBy(a => a.CategoryName);
            return View(categories);
        }
    }
}
