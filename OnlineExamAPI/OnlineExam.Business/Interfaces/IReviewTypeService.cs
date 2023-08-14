using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Business.Interfaces
{
    public interface IReviewTypeService
    {
        ReviewTypes GetReviewType(int ReviewTypeId);
        bool AddReviewType(ReviewTypes reviews);

    }
}
