using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.EntityFramework;
using BethanyPieShop.Models;

namespace BethanyPieShop.Services
{
    public class SqlFeedbackData : IFeedbackData
    {
        private readonly AppBethyDbContext _dbContext;

        public SqlFeedbackData(AppBethyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void AddFeedback(Feedback feedbackData)
        {
            _dbContext.Feedbacks.Add(feedbackData);
            _dbContext.SaveChanges();
        }
    }
}
