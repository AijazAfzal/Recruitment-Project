using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Business.Interfaces
{
    public interface IInterviewerReviewService
    {
       List<InterviewerReviewForm> GetInterviewerReviewFormAsync(int UserId);
        void AddInterviewerReview(List<CreateInterviewReview> reviews);
    }
}
