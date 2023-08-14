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
    public class EmployeeController : Controller
    {
        private readonly IUserProfile<EmpDetails> _onlineEmployee;
        public EmployeeController(IUserProfile<EmpDetails> onlineEmployee)
        {
            _onlineEmployee = onlineEmployee;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            IEnumerable<EmpDetails> users = _onlineEmployee.GetDetails();
            return Ok(users);
        }
    }
}
