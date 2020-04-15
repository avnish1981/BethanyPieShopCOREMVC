using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AlleryInformation { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfWeek { get; set; }
        public bool IsPieStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }
    }
}
