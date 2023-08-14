using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Business.BusinessLayer
{
   public class UserProfileBusiness : IUserProfile<UserProfile>
    {
        private readonly OnlineExamContext _onlineExamContext;
        public UserProfileBusiness(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }
        public void Add(UserProfile entity)
        {
            _onlineExamContext.UserProfile.Add(entity);
            _onlineExamContext.SaveChanges();
        }
        public void Delete(UserProfile entity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserProfile> GetAll()
        {
            return _onlineExamContext.UserProfile.ToList();
        }

        public IEnumerable<EmpDetails> GetDetails()
        {
            return _onlineExamContext.EmpDetails.ToList();
        }

        public void Update(UserProfile entity)
        {
            var user = _onlineExamContext.UserProfile
                .FirstOrDefault(e => e.UserId == entity.UserId);
            user.UserName = entity.UserName;
            user.MobileNo = entity.MobileNo;
            user.Experience = entity.Experience;
            user.Technology = entity.Technology;
            user.Response = entity.Response;
            _onlineExamContext.SaveChanges();
        }

        IEnumerable<UserProfile> IUserProfile<UserProfile>.GetDetails()
        {
            throw new NotImplementedException();
        }
    }
}
