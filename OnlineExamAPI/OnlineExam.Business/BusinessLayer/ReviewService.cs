using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Business.BusinessLayer
{
    public class ReviewService : IReviewService
    {
        private readonly OnlineExamContext _onlineExamContext;
        public ReviewService(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }
        public void AddUserReiew(List<UserReview> reviews)
        {
            for (int i = 0; i < reviews.Count;i++) 
                {
                reviews[i].ReviewDate = DateTime.Now;

            }
            _onlineExamContext.UserReview.AddRange(reviews);
            _onlineExamContext.SaveChanges();
        }

        public List<UserReview> GetUserReviews(int UserId)
        {
            return _onlineExamContext.UserReview
                .Where(e => e.UserId == UserId).ToList();
        }
    }
}
