using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using OnlineExam.Business.Interfaces;
using OnlineExam.Sql.Models;
using SendGridEmail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IOnlineExam<Users> _onlineExam;
        private readonly IUserProfile<UserProfile> _onlineUserProfile;
        private readonly Isendgrid _emailService;
        private readonly IEmailService _emailServices;
        public UserController(IOnlineExam<Users> onlineExam, IUserProfile<UserProfile> onlineUserProfile, Isendgrid emailService, IEmailService emailServices)
        {
            _onlineExam = onlineExam;
            _emailService = emailService;
            _emailServices = emailServices;
            _onlineUserProfile = onlineUserProfile;
        }
        [HttpGet]
        public IActionResult GetAllUsers([FromQuery] string? Email,string username,int technology)
        {
            IEnumerable<Users> users;
            if (!string.IsNullOrEmpty(Email))
            {
                users = _onlineExam.GetAll().Where(x => x.Email.Contains(Email)).OrderByDescending(x => x.CreatedDate);
            }
            else if (!string.IsNullOrEmpty(username))
            {
                users = _onlineExam.GetAll().Where(x => x.UserName.Contains(username)).OrderByDescending(x => x.CreatedDate);
            }
            else if (technology>0)
            {
                users = _onlineExam.GetAll().Where(x => x.Technology==technology).OrderByDescending(x => x.CreatedDate);
            }
            else
            {
                users = _onlineExam.GetAll().OrderByDescending(x => x.CreatedDate);
            }
            return Ok(users);
        }
        [HttpGet("{Userid}", Name = "GetUser")]
        public IActionResult GetUser(string Userid)
        {
            Users user = _onlineExam.GetByReference(Userid);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("user is null.");
            }
            _onlineExam.Add(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.UserId },
                  user);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("user is null.");
            }
            _onlineExam.Update(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.UserId },
                  user);
        }
        [HttpPut]
        [Route("UpdateUsers")]
        public IActionResult UpdateUsers([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("user is null.");
            }
            _onlineExam.UpdateUsers(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.UserId },
                  user);
        }

        [HttpPost]
        [Route("addProfile")]
        public IActionResult addProfile([FromBody] UserProfile user)
        {
            if (user == null)
            {
                return BadRequest("user is null.");
            }
            _onlineUserProfile.Add(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.UserId },
                  user);
        }

        [HttpPut]
        [Route("updateProfile")]
        public IActionResult updateProfile([FromBody] UserProfile user)
        {
            if (user == null)
            {
                return BadRequest("user is null.");
            }
            _onlineUserProfile.Update(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.UserId },
                  user);
        }

        [HttpGet]
        [Route("getAllProfile")]
        public IActionResult getAllProfile(string date)
        {
            IEnumerable<UserProfile> users = _onlineUserProfile.GetAll().OrderByDescending(x => x.createdDate);
            return Ok(users);
            //IEnumerable<UserProfile> users = _onlineUserProfile.GetAll().OrderByDescending(x => x.createdDate).Where(x => x.createdDate.Date == Convert.ToDateTime(date).Date);
            //return Ok(users);
        }
        [HttpPost("sendemail")]
        public IActionResult SendEmail(Users userDetails)
        {

            string body = PopulateBody(userDetails);
            _emailService.SendMail(userDetails, body);
            var user= _onlineExam.GetByReference(userDetails.UserReferenceId);
            user.CreatedDate = DateTime.Now;
            user.IsEmailSent = true;
            _onlineExam.Update(user);
            return Ok(true);
        }
        [HttpPost("SendReturnMailtoHr")]
        public IActionResult SendReturnMailtoHr(Users userDetails)
        {
            string body = PopulateBodyToHr(userDetails);
            _emailService.SendReturnMailtoHr(userDetails, body);
            return Ok(true);
        }
        private string PopulateBody(Users userDetails)
        {
            string body = string.Empty;
            string fileFullPath = $"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/CandidateExam.html";
            using (StreamReader reader = System.IO.File.OpenText(fileFullPath))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{url}", "https://ariqtonlineexamportal.azurewebsites.net/app-login-user?id=" + userDetails.UserReferenceId);
            body = body.Replace("{userName}", userDetails.UserName);
            return body;
        }
        private string PopulateBodyToHr(Users userDetails)
        {
            string body = string.Empty;
            string fileFullPath = $"{Directory.GetCurrentDirectory()}/wwwroot/EmailTemplates/RueturnMailToHr.html";
            using (StreamReader reader = System.IO.File.OpenText(fileFullPath))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{userName}", userDetails.UserName);
            body = body.Replace("{mailId}", userDetails.Email);
            return body;
        }

        [HttpPost("savefile/{userid}")]
        public async Task<IActionResult> PostFile([FromForm] IFormFile file,int userid)
        {
            await _emailServices.SaveResumeToBlob(file,userid);
            return Ok(true);
        }
        }
}
