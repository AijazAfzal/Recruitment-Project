using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineExam.Sql.Models
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int QuestionType { get; set; }
        public string Complexity { get; set; }
        public int Technology { get; set; }
        public string Uploadedby { get; set; }
        public string Approvedby { get; set; }
        public string Status { get; set; }
        public ICollection<CreateReview> Choices { get; set; }
    }
}
