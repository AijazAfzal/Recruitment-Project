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
    public class QuestionController : Controller
    {
        private readonly IOnlineExam<Questions> _onlineExam;
        public QuestionController(IOnlineExam<Questions> onlineExam)
        {
            _onlineExam = onlineExam;
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            IEnumerable<Questions> questions = _onlineExam.GetAll();
            return Ok(questions);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Questions question = _onlineExam.Get(id);
            if (question == null)
            {
                return NotFound("The Question record couldn't be found.");
            }
            return Ok(question);
        }
        [HttpGet("technology/{id}", Name = "GetList")]
        public IActionResult GetList(int id)
        {
            var question = _onlineExam.GetList(id);
            if (question == null)
            {
                return NotFound("The Question record couldn't be found.");
            }
            return Ok(question);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Questions question)
        {
            if (question == null)
            {
                return BadRequest("Question is null.");
            }
            _onlineExam.Add(question);
            return CreatedAtRoute(
                  "Get",
                  new { Id = question.QuestionId },
                  question);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Questions question)
        {
            if (question == null)
            {
                return BadRequest("question is null.");
            }

            _onlineExam.Update(question);
            return Ok(question);
        }
        [HttpPut]
        [Route("ApproveQuestion")]
        public IActionResult ApproveQuestion([FromBody] Questions questions)
        {
            if (questions == null)
            {
                return BadRequest("user is null.");
            }
            _onlineExam.ApproveQuestion(questions);
            return CreatedAtRoute(
                  "Get",
                  new { Id = questions.QuestionId },
                  questions);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Questions question)
        {
            if (question == null)
            {
                return BadRequest("question is null.");
            }

            _onlineExam.Delete(question);
            return Ok(question);
        }

    }
}
