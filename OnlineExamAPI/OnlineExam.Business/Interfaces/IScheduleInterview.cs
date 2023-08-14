using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Business.Interfaces
{
   public interface IScheduleInterview<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
