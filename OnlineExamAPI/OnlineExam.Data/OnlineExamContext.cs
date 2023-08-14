using Microsoft.EntityFrameworkCore;
using OnlineExam.Sql.Models;
using System;

namespace OnlineExam.Data
{
    public class OnlineExamContext:DbContext
    {
        public OnlineExamContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<CreateReview> Choices { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }
        public DbSet<Technologies> Technologies { get; set; }
        public DbSet<ReviewQuestions> ReviewQuestions { get; set; }
        public DbSet<UserReview> UserReview { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<EmpDetails> EmpDetails { get; set; }
        public DbSet<ScheduleInterview> ScheduleInterview { get; set; }
        public DbSet<InterViewType> InterViewType { get; set; }

        public DbSet<ReviewTypes> ReviewTypes { get; set; }

        public DbSet<InterviewerReviewForm> InterviewerReviewForms { get; set; }

    }
}
