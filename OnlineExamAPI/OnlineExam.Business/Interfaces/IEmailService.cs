using Microsoft.AspNetCore.Http;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Business.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(ExamEmail email);

        Task SaveResumeToBlob(IFormFile file,int userId);

        
    }
}
