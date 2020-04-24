using BethanyPieShop.Services;
using BethanyPieShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shopping;

        public ShoppingCartSummary(ShoppingCart shopping)
        {
            this._shopping = shopping;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shopping.GetShoppingCartItems();
            _shopping.ShoppingCartItems   = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shopping,
                ShoppingCartTotal = _shopping.GetShoppingCartTotal()

            };
            return View(shoppingCartViewModel);

        }

    }
}
