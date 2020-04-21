using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;
using BethanyPieShop.Services;
using BethanyPieShop.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BethanyPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IPieData _pieData;

        public HomeController(IConfiguration config,IPieData pieData)
        {
            this._config = config;
            this._pieData = pieData;
        }
        [Authorize]
        public IActionResult Index()
        {
            var pieData = new HomeViewModel
            {
                PiesOftheweek = _pieData.PiesOfTheWeek 

            };
                             

           ViewBag.Enviorment = _config["MyKey"];
            return View(pieData);
        }
    }
}