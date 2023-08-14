using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam.Sql.Models
{
    public class InterviewerReviewForm
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ReviewId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual Users User { get; set; }

        [ForeignKey("ReviewTypeId")]
        public int ReviewTypeId { get; set; }

        public virtual ReviewTypes ReviewType { get; set; }
        public int Rating { get; set; }

        public string Comments { get; set; }


      
   




    }
}
