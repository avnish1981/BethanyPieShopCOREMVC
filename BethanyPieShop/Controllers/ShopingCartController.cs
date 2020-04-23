using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Services;
using BethanyPieShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieData _pieData ;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPieData pieData , ShoppingCart shoppingCart)
        {
            _pieData = pieData;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var selectedPie = _pieData.AllPie.FirstOrDefault(p => p.PieId == id);

            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var selectedPie = _pieData.AllPie.FirstOrDefault(p => p.PieId == id);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}