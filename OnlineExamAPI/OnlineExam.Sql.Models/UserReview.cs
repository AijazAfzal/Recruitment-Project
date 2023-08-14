using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.Sql.Models
{
    public class UserReview
    {
       [key]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int? UserId { get; set; }
      //  public virtual Users User { get; set; }
        public DateTime ReviewDate { get; set; }
        [ForeignKey("ReviewQuestions")]
        //  public virtual ReviewQuestions ReviewQuestions { get; set; }
        public int? ReviewQuestionsId { get; set; }
        public string Review { get; set; }
    }
}
