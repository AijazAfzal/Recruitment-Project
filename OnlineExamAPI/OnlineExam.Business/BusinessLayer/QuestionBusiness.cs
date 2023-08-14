using Microsoft.EntityFrameworkCore;
using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Business.BusinessLayer
{
    public class QuestionBusiness:IOnlineExam<Questions>
    {
        private readonly OnlineExamContext _onlineExamContext;

        public QuestionBusiness(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }

        public bool Add(Questions entity)
        {
            _onlineExamContext.Questions.Add(entity);
            _onlineExamContext.SaveChanges();
            return true;
        }

        public void AddMultiple(List<Questions> entity)
        {
            throw new NotImplementedException();
        }

        public void ApproveQuestion(Questions entity)
        {
            var question = _onlineExamContext.Questions
                 .FirstOrDefault(e => e.QuestionId == entity.QuestionId);
            question.Status = entity.Status;
            question.Approvedby = entity.Approvedby;
            _onlineExamContext.SaveChanges();
        }

        public void Delete(Questions entity)
        {
            _onlineExamContext.Questions.Remove(entity);
            _onlineExamContext.SaveChanges();
        }

        public Questions Get(int QuestionId)
        {
            return _onlineExamContext.Questions
                  .FirstOrDefault(e => e.QuestionId == QuestionId);
        }

        public IEnumerable<Questions> GetAll()
        {
            var questions = _onlineExamContext.Questions.Include("Choices").ToList();
            // Choose n number of random questions.
            var randomquestions = questions.ToList();  
            return randomquestions;
        }

        public Questions GetByReference(string RefId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Questions> GetList(int Id)
        {
            var randomquestions = new List<Questions>();
            
            var rnd = new Random();
            var questions = _onlineExamContext.Questions.Include("Choices").ToList();
            // Choose n number of random questions.
            var multipleQuestions = questions.Where(x => x.Technology == Id && x.QuestionType==1).OrderBy(id => rnd.Next());
            //var programQuestions = questions.Where(x => x.Technology == Id && x.QuestionType == 2).OrderBy(id => rnd.Next()).Take(5);
            var writeaprogramQuestions = questions.Where(x => x.Technology == Id && x.QuestionType == 3).OrderBy(id => rnd.Next());
            randomquestions.AddRange(multipleQuestions);
            //randomquestions.AddRange(programQuestions);
            randomquestions.AddRange(writeaprogramQuestions);
            return randomquestions;
        }
        public void Update(Questions entity)
        {
            var question = _onlineExamContext.Questions
                 .FirstOrDefault(e => e.QuestionId == entity.QuestionId);
            question.Question = entity.Question;
            question.QuestionType = entity.QuestionType;
            question.Complexity = entity.Complexity;           
            _onlineExamContext.SaveChanges();
        }

        public void UpdateUsers(Questions entity)
        {
            throw new NotImplementedException();
        }
    }
}
