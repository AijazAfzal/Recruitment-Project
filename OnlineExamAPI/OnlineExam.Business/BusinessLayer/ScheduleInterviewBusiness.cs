using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Business.BusinessLayer
{
    public class ScheduleInterviewBusiness : IScheduleInterview<ScheduleInterview>
    {
        private readonly OnlineExamContext _onlineExamContext;
        public ScheduleInterviewBusiness(OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
        }

        public void Add(ScheduleInterview entity)
        {
            _onlineExamContext.ScheduleInterview.Add(entity);
            _onlineExamContext.SaveChanges();
        }

        public void Delete(ScheduleInterview entity)
        {
            var user = _onlineExamContext.ScheduleInterview
              .FirstOrDefault(e => e.UserId == entity.UserId);
            _onlineExamContext.ScheduleInterview.Remove(user);
            _onlineExamContext.SaveChanges();
        }

        public ScheduleInterview Get(int UserId)
        {
            return _onlineExamContext.ScheduleInterview
                 .FirstOrDefault(e => e.UserId == UserId);
        }

        public IEnumerable<ScheduleInterview> GetAll()
        {
            return _onlineExamContext.ScheduleInterview.ToList();
        }

        public void Update(ScheduleInterview entity)
        {
            var schedule = _onlineExamContext.ScheduleInterview
                .FirstOrDefault(e => e.UserId == entity.UserId);
            schedule.InterviewType = entity.InterviewType;
            schedule.InterviewDate = entity.InterviewDate;
            schedule.InterviewTime = entity.InterviewTime;
            schedule.ZoomLink = entity.ZoomLink;
            schedule.InterviewerName = entity.InterviewerName;
            schedule.CreatedDate = entity.CreatedDate;
            schedule.CreatedBy=entity.CreatedBy;
            schedule.InterviewStatus = entity.InterviewStatus;
            _onlineExamContext.SaveChanges();
        }
    }
}
