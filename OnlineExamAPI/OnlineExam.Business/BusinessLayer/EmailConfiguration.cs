using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Business.BusinessLayer
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string EmailFunctionCode { get; set; }
    }
    public interface IEmailConfiguration
    {
        public string EmailFunctionCode { get; set; }
    }
}
