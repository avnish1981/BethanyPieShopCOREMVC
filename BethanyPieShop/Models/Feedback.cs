using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        
        public string Name { get; set; }
        public string Email { get; set; }
        
        public string Message { get; set; }
        public bool ContactMe { get; set; }
    }
}
