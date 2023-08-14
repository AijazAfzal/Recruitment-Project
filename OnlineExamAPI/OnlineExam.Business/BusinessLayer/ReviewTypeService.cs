using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Business.BusinessLayer
{
    public class ReviewTypeService : IReviewTypeService
    {
        private readonly OnlineExamContext _onlineExamContext;
        public ReviewTypeService(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }
        public bool AddReviewType(ReviewTypes reviews)
        {
         var existrev= _onlineExamContext.ReviewTypes
               .FirstOrDefault(e => e.ReviewType.ToLower() == reviews.ReviewType.ToLower());
            if (existrev != null)
            {
                return false;
            }
            _onlineExamContext.ReviewTypes.Add(reviews);
            _onlineExamContext.SaveChanges();
            return true;
        }

        public ReviewTypes GetReviewType(int ReviewTypeId)
        {
            return _onlineExamContext.ReviewTypes
               .FirstOrDefault(e => e.ReviewTypeId == ReviewTypeId);
        }
    }
}
