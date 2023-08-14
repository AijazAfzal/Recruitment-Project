using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Sql.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridEmail
{
    public class SendGridMail : Isendgrid
    {
        public SendGridMail()
        {

        }

        public async Task SendMail(Users userDetails, string body)
        {

            var apiKey = "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";
            //System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("hr@ariqt.com", "Ariqt"),
                Subject = "Exam Schedule Ariqt",
                PlainTextContent = "Hello, Email!",
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(userDetails.Email, userDetails.UserName));
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendEvaluationMail(Users userDetails, string body)
        {

            var apiKey = "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";
            //System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("hr@ariqt.com", "Ariqt"),
                Subject = "Interview Evaluation Ariqt",
                PlainTextContent = "Hello, Email!",
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(userDetails.Interviewer, userDetails.UserName));
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendScheduleMail(ScheduleInterview scheduleInterview,Users userdetails, string body)
        {
            var apiKey = "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";
            
            //System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("hr@ariqt.com", "Ariqt"),
                Subject = "Exam Schedule Ariqt",
                PlainTextContent = "Hello, Email!",
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(userdetails.Email, userdetails.UserName));
            var response = await client.SendEmailAsync(msg);
        }
        public async Task SendReturnMailtoHr(Users userDetails, string body)
        {

            var apiKey = "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";
            //System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("hr@ariqt.com", "Ariqt"),
                Subject = "Exam Schedule Ariqt",
                PlainTextContent = "Hello, Email!",
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress("hr@ariqt.com", userDetails.UserName));
            var response = await client.SendEmailAsync(msg);
        }

    }
}
