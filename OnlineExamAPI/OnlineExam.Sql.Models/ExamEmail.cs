using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Sql.Models
{
    public class ExamEmail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
    }
}
