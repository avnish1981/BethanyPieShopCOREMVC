﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Services;
using BethanyPieShop.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieData _pieData;
        private readonly ICategoryData _categoryData;

        public PieController(IPieData pieData,ICategoryData categoryData)
        {
            this._pieData = pieData;
            this._categoryData = categoryData;
        }
        [Authorize]
        public ViewResult   List()
        {
            /*  ViewBag.Currentcategory = "Cheese cake";
              var model = _pieData.AllPie;
              return View(model); */
            PiesListViewModel piesListView = new PiesListViewModel();
            piesListView.Pies = _pieData.AllPie;
            piesListView.Currency = "INR";
            return View(piesListView);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var pie = _pieData.GetPieById(id);
            if(pie ==null)
            {
                return View("NotFound");
            }
            return View(pie);
        }
    }
}