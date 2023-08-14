using Microsoft.AspNetCore.Mvc;
using OnlineExam.Business.Interfaces;
using OnlineExam.Sql.Models;

namespace OnlineExamFormApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewTypeController : Controller
    {
        private readonly IReviewTypeService _reviewTypeService;

            public ReviewTypeController(IReviewTypeService reviewTypeService)
            {
                _reviewTypeService = reviewTypeService;
            }


            [HttpPost]
            public IActionResult Post([FromBody] ReviewTypes reviewType)
            {
                bool res=_reviewTypeService.AddReviewType(reviewType);
            if(res)
                return Ok("data added sucessfully");
            return Ok("data existed");
        }


        [HttpGet("{id}", Name = "GetReviewType")]
        public IActionResult GetReviewType(int id)
        {
            var reviewType = _reviewTypeService.GetReviewType(id);
            
            return Ok(reviewType);
        }
    }

}