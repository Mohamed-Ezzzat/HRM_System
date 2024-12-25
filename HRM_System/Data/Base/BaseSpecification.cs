using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace HRM_System.Data.Base
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> Order { get; set; }
        public Expression<Func<T, object>> OrderBydessending { get; set; }

        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }

       
        public void AddInclude(Expression<Func<T, object>> Include)
        {
            Includes.Add(Include);
        }
        public void AddOrder(Expression<Func<T, object>> orderby)
        {
            Order = orderby;
        }
        public void AddOrderRyDessending(Expression<Func<T, object>> orderbydessending)
        {
            OrderBydessending = orderbydessending;
        }
    }
}
