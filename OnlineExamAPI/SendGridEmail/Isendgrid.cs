using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SendGridEmail
{
    public interface Isendgrid
    {
        Task SendMail(Users userDetails, string body);
        Task SendScheduleMail(ScheduleInterview scheduleInterview, Users userdetails, string body);
        Task SendReturnMailtoHr(Users userDetails, string body);
        Task SendEvaluationMail(Users userDetails, string body);
    }
}
