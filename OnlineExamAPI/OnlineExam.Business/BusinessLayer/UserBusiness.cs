using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExam.Business.BusinessLayer
{
    public class UserBusiness : IOnlineExam<Users>
    {
        private readonly OnlineExamContext _onlineExamContext;
        public UserBusiness(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }
        public bool Add(Users entity)
        {
            entity.ExamStatus = 1;
            entity.UserReferenceId = Guid.NewGuid().ToString();

            var ExistingUser = _onlineExamContext.Users.FirstOrDefault(e => e.Email == entity.Email ||e.MobileNo==entity.MobileNo);

            if(ExistingUser == null)
            {
                _onlineExamContext.Users.Add(entity);
                _onlineExamContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
        

        public void AddMultiple(List<Users> entity)
        {
            throw new NotImplementedException();
        }

        public void AddProfile(Users entity)
        {
            throw new NotImplementedException();
        }

        public void ApproveQuestion(Users entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public Users Get(int UserId)
        {
            return _onlineExamContext.Users
                 .FirstOrDefault(e => e.UserId == UserId);
        }

        public IEnumerable<Users> GetAll()
        {
            return _onlineExamContext.Users.ToList();
        }

        public Users GetByReference(string RefId)
        {
            return _onlineExamContext.Users
                 .FirstOrDefault(e => e.UserReferenceId == RefId);
        }

        public IEnumerable<Users> GetList(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Users entity)
        {
            var user= _onlineExamContext.Users
                 .FirstOrDefault(e => e.UserId == entity.UserId);

            user.UserName = entity.UserName;
            user.MobileNo = entity.MobileNo;
            user.Email = entity.Email;
            user.Experience = entity.Experience;
            user.Technology = entity.Technology;
            user.CurrentOrgnization = entity.CurrentOrgnization;
            user.CurrentCTC = entity.CurrentCTC;
            user.ExpectedSalary = entity.ExpectedSalary;
            user.NoticePeriod = entity.NoticePeriod;
            user.Contactedby = entity.Contactedby;
            user.Source = entity.Source;
            user.InterviewDate=entity.InterviewDate;
            user.Interviewer=entity.Interviewer;
            user.Position=entity.Position;
            user.UserStatus=entity.UserStatus;
            _onlineExamContext.SaveChanges();
        }
        public void UpdateUsers(Users entity)
        {
            var user = _onlineExamContext.Users
                  .FirstOrDefault(e => e.UserId == entity.UserId);
            user.UserName = entity.UserName;
            user.MobileNo = entity.MobileNo;
            user.Email = entity.Email;
            user.Experience = entity.Experience;
            user.Technology = entity.Technology;
            user.CurrentOrgnization = entity.CurrentOrgnization;
            user.CurrentCTC = entity.CurrentCTC;
            user.ExpectedSalary = entity.ExpectedSalary;
            user.NoticePeriod = entity.NoticePeriod;
            user.Contactedby = entity.Contactedby;
            //user.Source = entity.Source;
            //user.InterviewDate = entity.InterviewDate;
            user.Interviewer = entity.Interviewer;
            user.UserStatus = entity.UserStatus;
            //user.Position = entity.Position;
            _onlineExamContext.SaveChanges();
        }
    }
}
