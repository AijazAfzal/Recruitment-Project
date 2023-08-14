using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Business.BusinessLayer
{
    public class ChoiceBusiness : IOnlineExam<CreateReview>
    {
        private readonly OnlineExamContext _onlineExamContext;
        public ChoiceBusiness(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }

        public bool Add(CreateReview entity)
        {
            _onlineExamContext.Choices.Add(entity);
            _onlineExamContext.SaveChanges();
            return true;
        }

        public void AddMultiple(List<CreateReview> entity)
        {
            _onlineExamContext.Choices.AddRange(entity);
            _onlineExamContext.SaveChanges();
        }

        public void ApproveQuestion(CreateReview entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CreateReview entity)
        {
            throw new NotImplementedException();
        }

        public CreateReview Get(int QuestionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreateReview> GetAll()
        {
            return _onlineExamContext.Choices.ToList();
        }

        public CreateReview GetByReference(string RefId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreateReview> GetList(int Id)
        {
            return _onlineExamContext.Choices.Where(e => e.QuestionId == Id).ToList();
        }

        public void Update(CreateReview entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsers(CreateReview entity)
        {
            throw new NotImplementedException();
        }
    }
}
    
