using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Business.BusinessLayer
{
    public class UserAnswerBusiness : IOnlineExam<UserAnswers>
    {
        private readonly OnlineExamContext _onlineExamContext;
        public UserAnswerBusiness(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }

        public bool Add(UserAnswers entity)
        {
            _onlineExamContext.UserAnswers.Add(entity);
            _onlineExamContext.SaveChanges();
            return true;
        }

        public void AddMultiple(List<UserAnswers> entity)
        {
            _onlineExamContext.UserAnswers.AddRange(entity);
            _onlineExamContext.SaveChanges();
        }

        public void ApproveQuestion(UserAnswers entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserAnswers entity)
        {
            throw new NotImplementedException();
        }

        public UserAnswers Get(int QuestionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAnswers> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserAnswers GetByReference(string RefId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAnswers> GetList(int Id)
        {
            return _onlineExamContext.UserAnswers.Where(e => e.UserId == Id).ToList();
        }

        public void Update(UserAnswers entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsers(UserAnswers entity)
        {
            throw new NotImplementedException();
        }
    }
}
    
