using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Business.Interfaces
{
   public interface IReviewService
    {
        List<UserReview> GetUserReviews(int UserId);
        void AddUserReiew(List<UserReview> reviews);

    }
}
