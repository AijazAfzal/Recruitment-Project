using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Business.Interfaces
{
    public interface IOnlineExam<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetList(int Id);
        TEntity Get(int QuestionId);
        TEntity GetByReference(string RefId);
        bool Add(TEntity entity);
        void AddMultiple(List<TEntity> entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void ApproveQuestion(TEntity entity);
        void UpdateUsers(TEntity entity);



        
    }
}
