using Microsoft.EntityFrameworkCore;
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
    public class InterviewerReviewService : IInterviewerReviewService
    {
        private readonly OnlineExamContext _onlineExamContext;
        public InterviewerReviewService(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }
        public void AddInterviewerReview(List<CreateInterviewReview> reviews)
        {
            var intervrevs= _onlineExamContext.InterviewerReviewForms
               .Where(e => e.UserId == reviews[0].UserId).ToList();
            if (intervrevs.Count() == 0)
            {
                var revs = new List<InterviewerReviewForm>();
                foreach (var review in reviews)
                {
                    var rev = new InterviewerReviewForm
                    {
                        UserId = review.UserId,
                        ReviewTypeId = review.ReviewTypeId,
                        Rating = review.Rating,
                        Comments = review.Comments,
                    };
                    revs.Add(rev);
                }
                _onlineExamContext.InterviewerReviewForms.AddRange(revs);
                _onlineExamContext.SaveChanges();
                var user=_onlineExamContext.Users.FirstOrDefault(x=>x.UserId==reviews[0].UserId);
                user.IsReviewGiven= true;
                user.UserStatus = "Evaluation Submitted";
                _onlineExamContext.SaveChanges();
            }
            else
            {

            }
        }

        public List<InterviewerReviewForm> GetInterviewerReviewFormAsync(int UserId)
        {
            return _onlineExamContext.InterviewerReviewForms
               .Where(e => e.UserId == UserId).ToList();
        }

        
    }
}
