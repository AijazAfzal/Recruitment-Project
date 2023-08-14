using Microsoft.AspNetCore.Mvc;
using OnlineExam.Business.Interfaces;
using OnlineExam.Sql.Models;

namespace OnlineExamFormApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerReviewFormController : Controller
    {
        private readonly IInterviewerReviewService _iInterviewReviewService;

        
        public InterviewerReviewFormController(IInterviewerReviewService interviewReviewService)
        {
            _iInterviewReviewService = interviewReviewService;
        }


        [HttpPost]
        public IActionResult Post([FromBody] List<CreateInterviewReview> interviewerReviewForm)
        {
            _iInterviewReviewService.AddInterviewerReview(interviewerReviewForm);
            return Ok(interviewerReviewForm);
        }


        [HttpGet("{Userid}", Name = "GetInterviewerReview")]
        public IActionResult GetInterviewerReviewForm(int Userid)
        {
            var interviewerReviewForm = _iInterviewReviewService.GetInterviewerReviewFormAsync(Userid);
            if (interviewerReviewForm.Count == 0)
            {
                return NotFound("There is no data");
            }
            return Ok(interviewerReviewForm);
        }

    }
}
