using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TalbatCore.Entites;
using TalbatCore.Specifications;

namespace TalbatRepository
{
    internal static class SpecificationEvaluation <T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery ,  ISpecification<T> spec) {
            var query = inputQuery;
            if (spec.Cratiral is not null) { 
            
                query = query.Where(spec.Cratiral);
            }
            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.IsPagainationEnable) {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            else if (spec.OrderByDece is not null)
            {
                query = query.OrderByDescending(spec.OrderByDece);
            }
            query = spec.Includes.Aggregate(query, (current, IncludeExpression) =>  current.Include(IncludeExpression));

            return query;
        
        }
    }
}
