using Microsoft.AspNetCore.Mvc;
using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public UserReviewController( IReviewService reviewService)
        {
            
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<UserReview> userReviews)
        {
             _reviewService.AddUserReiew(userReviews);
            
            return Ok("data added sucessfully");
        }

        [HttpGet("{id}", Name = "GetReview")]
        public IActionResult GetUserreviews(int id)
        {
            var userReviews = _reviewService.GetUserReviews(id);
            if (userReviews.Count==0)
            {
                return NotFound("The Question record couldn't be found.");
            }
            return Ok(userReviews);
        }
    }
}
