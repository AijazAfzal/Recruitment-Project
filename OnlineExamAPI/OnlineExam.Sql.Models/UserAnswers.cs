using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineExam.Sql.Models
{
    public class UserAnswers
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Questions Question { get; set; }
        public int? QuestionId { get; set; }
        [ForeignKey("ChoiceId")]
        public virtual CreateReview Choice { get; set; }
        public int? ChoiceId { get; set; }

        public string Code { get; set; }

    }
}
