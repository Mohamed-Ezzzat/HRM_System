using System.Linq;
using HRM_System.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM_System.Data.Base
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);
            if (spec.Order != null)
                query = query.OrderBy(spec.Order);
            if (spec.OrderBydessending != null)
                query = query.OrderByDescending(spec.OrderBydessending);

            query = spec.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));

            return query;
        }
    }
}
