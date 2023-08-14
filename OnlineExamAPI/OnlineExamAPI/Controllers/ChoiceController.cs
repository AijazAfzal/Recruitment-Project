using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Business.Interfaces;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : Controller
    {
        private readonly IOnlineExam<CreateReview> _onlineExam;
        public ChoiceController(IOnlineExam<CreateReview> onlineExam)
        {
            _onlineExam = onlineExam;
        }

      

        [HttpPost]
        public IActionResult Post([FromBody] CreateReview Choice)
        {
            if (Choice == null)
            {
                return BadRequest("Question is null.");
            }
            _onlineExam.Add(Choice);
            return Ok(Choice.ChoiceId);
        }

        [HttpPost("Bulk")]
        public IActionResult Post([FromBody] List<CreateReview> Choice)
        {
            if (Choice.Count == 0)
            {
                return BadRequest("Answers are null.");
            }
            _onlineExam.AddMultiple(Choice);
            return Ok(true);
        }
    }
}
