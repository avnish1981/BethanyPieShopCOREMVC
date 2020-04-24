using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;
using BethanyPieShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackData _feedbackData;

        public FeedbackController(IFeedbackData feedbackData)
        {
            this._feedbackData = feedbackData;
            
        }

       
        [HttpGet ]
        public IActionResult Index()
        { 
           return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken ]
        public IActionResult Index(Feedback feedback )
        {
            _feedbackData.AddFeedback(feedback);
            return RedirectToAction("feedbackComplete");
        }
        public IActionResult feedbackComplete()
        {
            return View();
        }
    }
}