using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace HRM_System.Data.Base
{
    public interface ISpecification <T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> Order { get; set; }
        public Expression<Func<T, object>> OrderBydessending { get; set; }
    }
}
