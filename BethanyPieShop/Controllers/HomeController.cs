using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BethanyPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            this._config = config;
        }
        public IActionResult Index()
        {
            ViewBag.Enviorment = _config["MyKey"];
            return View();
        }
    }
}