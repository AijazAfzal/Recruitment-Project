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
    public class AnswerController : Controller
    {
        private readonly IOnlineExam<UserAnswers> _onlineExam;
        public AnswerController(IOnlineExam<UserAnswers> onlineExam)
        {
            _onlineExam = onlineExam;
        }



        [HttpPost]
        public IActionResult Post([FromBody] List<UserAnswers> Answers)
        {
            if (Answers.Count == 0)
            {
                return BadRequest("Answers are null.");
            }
            _onlineExam.AddMultiple(Answers);
            return Ok(true);
        }

        [HttpGet("{id}", Name = "GetUserAnswers")]
        public IActionResult GetUserAnswers(int id)
        {
            IEnumerable<UserAnswers> answers = _onlineExam.GetList(id);
            return Ok(answers);
        }
    }
}
