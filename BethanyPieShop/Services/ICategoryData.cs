﻿using BethanyPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Services
{
    public interface ICategoryData
    {
        IEnumerable<Category> AllCategories { get;  }
    }
}
