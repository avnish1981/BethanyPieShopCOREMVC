using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.EntityFramework;
using BethanyPieShop.Models;

namespace BethanyPieShop.Services
{
    public class SqlOrderData : IOrderData
    {
        private readonly AppBethyDbContext _dbContext;
        private readonly ShoppingCart _shoppingCart;

        public SqlOrderData(AppBethyDbContext dbContext,ShoppingCart shoppingCart)
        {
            this._dbContext = dbContext;
            this._shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _dbContext.Orders.Add(order);

            var shoppingcartItems = _shoppingCart.ShoppingCartItems;
            foreach(var shoppingcartItem in shoppingcartItems  )
            {
                var orderDetails = new OrderDetails
                {
                    Amount = shoppingcartItem.Amount,
                    PieId = shoppingcartItem.Pie.PieId,
                    OrderId = order.OrderId,
                    Price = shoppingcartItem.Pie.Price
                };
                _dbContext.OrderDetails.Add(orderDetails);
            }
            _dbContext.SaveChanges();
           
        }
    }
}
