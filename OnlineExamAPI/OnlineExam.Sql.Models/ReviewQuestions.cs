using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Sql.Models
{
    public class ReviewQuestions
    {
       [key]
        public int ReviewQuestionsId { get; set; }

        public string ReviewQuestion { get; set; }
    }
}
