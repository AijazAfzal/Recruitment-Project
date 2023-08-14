using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineExam.Sql.Models
{
    public class ScheduleInterview
    {
        [key]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("InterViewType")]
        public int InterviewType { get; set; }

        public DateTime InterviewDate { get; set; }

        public string InterviewTime { get; set; }

        public string ZoomLink { get; set; }

        public string InterviewerName { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string InterviewStatus { get; set; }


    }
}
