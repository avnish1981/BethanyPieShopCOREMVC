using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;
using BethanyPieShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderData _order;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderData order ,ShoppingCart shoppingCart)
        {
            this._order = order;
            this._shoppingCart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [ValidateAntiForgeryToken ]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if(_shoppingCart.ShoppingCartItems.Count==0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");

            }
            if(ModelState.IsValid)
            {
                _order.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutMessage = "Thanks for your order . You will soon enjoy our delicious pies !";
            return View();
        }
    }
}