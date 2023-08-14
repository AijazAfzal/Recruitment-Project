using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Sql.Models
{
    public class CreateInterviewReview
    {
        public int UserId { get; set; }

        public int ReviewTypeId { get; set; }
        public int Rating { get; set; }

        public string Comments { get; set; }

    }
}
