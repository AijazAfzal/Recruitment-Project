using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.Sql.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string MobileNo { get; set; }
        public decimal Experience { get; set; }
        public int Technology { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ExamStatus { get; set; }
        public string UserReferenceId { get; set; }
        public bool IsEmailSent { get; set; }
        public string CurrentOrgnization { get; set; }
        public decimal CurrentCTC { get; set; }
        public decimal ExpectedSalary { get; set; }
        public int NoticePeriod { get; set; }
        public string Contactedby { get; set; }
        public string UploadResume { get; set; }
        public string Source { get; set; }
        public string? Interviewer { get; set; }
        public DateTime? InterviewDate { get; set; }

        public string? Position { get; set; }

        public string? UserStatus { get; set; }
        public string? SourceName { get; set; }
        public bool? IsReviewGiven { get; set; }

        public string? Qualification { get; set; }
        public int? CommunicationRating { get; set; }
        public int? LogicalRating { get; set; }
        public int? CodingRating { get; set; }

    }
}
