using Microsoft.AspNetCore.Mvc;
using OnlineExam.Business.Interfaces;
using OnlineExam.Sql.Models;
using SendGridEmail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleInterviewController : Controller
    {
        private readonly IScheduleInterview<ScheduleInterview> _onlineScheduleInterview;
        private readonly Isendgrid _emailService;
        private readonly IEmailService _emailServices;
        private readonly IOnlineExam<Users> _onlineExam;
        public ScheduleInterviewController(IScheduleInterview<ScheduleInterview> onlineExamScheduleInterview,Isendgrid emailService, IEmailService emailServices, IOnlineExam<Users> onlineExam)
        {
            _onlineExam = onlineExam;
            _emailService = emailService;
            _emailServices = emailServices;
            _onlineScheduleInterview = onlineExamScheduleInterview;
        }
        [HttpPost]
        public IActionResult Post([FromBody] ScheduleInterview schedule)
        {
            if (schedule == null)
            {
                return BadRequest("user is null.");
            }
            _onlineScheduleInterview.Add(schedule);
            return CreatedAtRoute(
                  "Get",
                  new { Id = schedule.UserId },
                  schedule);
        }
        [HttpPut]
        public IActionResult Put([FromBody] ScheduleInterview schedule)
        {
            if (schedule == null)
            {
                return BadRequest("user is null.");
            }
            _onlineScheduleInterview.Update(schedule);
            return CreatedAtRoute(
                  "Get",
                  new { Id = schedule.UserId },
                  schedule);
        }
        [HttpPost("sendemail")]
        public IActionResult SendEmail(ScheduleInterview scheduleInterview)
        {

            var userdetails = _onlineExam.Get(scheduleInterview.UserId);
            string body = PopulateBody(scheduleInterview, userdetails);
            _emailService.SendScheduleMail(scheduleInterview, userdetails, body);
            return Ok(true);
        }
        private string PopulateBody(ScheduleInterview scheduleInterview,Users userDetails)
        {
            string body = string.Empty;
            string technology=string.Empty;
            if (userDetails.Technology == 1)
            {
                technology = ".Net";
            }
            else if (userDetails.Technology == 2)
            {
                technology = "Angular";
            }
            if (scheduleInterview.ZoomLink != "")
            {
               
                string fileFullPath = $"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/InterviewScheduletemplate.html";
                using (StreamReader reader = System.IO.File.OpenText(fileFullPath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{userName}", userDetails.UserName);
                body = body.Replace("{contextHeading}", "Meeting Ariqt is inviting you to a scheduled zoom meeting.<br/><br/>");
                body = body.Replace("{Topic}", "Topic: Meeting with " + userDetails.UserName + " for " + technology + "<br/><br/>");
                body = body.Replace("{Time}", "<b>Date & Time: </b>" + scheduleInterview.InterviewDate.ToString("dd-MM-yyyy") + " " + scheduleInterview.InterviewTime + " India" +"<br/><br/><b>Join Zoom Meeting</b><br/>");
                string[] resultZoomLink = scheduleInterview.ZoomLink.Split("@@");
                string zoomlink = resultZoomLink[0];
                string[] resultmeetingId = resultZoomLink[1].Split("$$");
                string meetingId = resultmeetingId[0];
                string passcode = resultmeetingId[1];
                body = body.Replace("{contextdata}", zoomlink+ "<br/><br/>" + "Meeting Id: "+meetingId + "<br/><br/>" + "PassCode: "+passcode);
            }
            else if (scheduleInterview.InterviewerName != "")
            {
                string fileFullPath = $"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/InterviewScheduletemplate.html";
                using (StreamReader reader = System.IO.File.OpenText(fileFullPath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{userName}", userDetails.UserName);
                body = body.Replace("{contextHeading}", "Meeting Ariqt is inviting you to a scheduled face to face interview.<br/>");
                body = body.Replace("{Topic}", "Topic: Interview with " + userDetails.UserName + " for " + technology + "<br/><br/>");
                body = body.Replace("{Time}", "<b>Date & Time: " + scheduleInterview.InterviewDate.ToString("dd-MM-yyyy") + " " + scheduleInterview.InterviewTime + " India</b><br/><br/>");
                body = body.Replace("{contextdata}", "InterviewerName: " + scheduleInterview.InterviewerName);
            }
            return body;

        }

    }
}
