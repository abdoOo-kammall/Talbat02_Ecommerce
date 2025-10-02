using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalbatCore.Entites;

namespace TalbatCore.Specifications
{
    public class Specification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Cratiral { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set ; } = new List<Expression<Func<T, object>>> ();
        public Expression<Func<T, object>> OrderBy { get; set; } = null;
        public Expression<Func<T, object>> OrderByDece { get; set; } = null;
        public int Skip { get; set ; }
        public int Take { get; set ; }
        public bool IsPagainationEnable { get; set; }


        public Specification()
        {
            
        }
        public Specification(Expression <Func<T , bool>> cratiral)
        {
            Cratiral = cratiral;
        }
        public void applyPagaination(int skip , int take) {
            IsPagainationEnable = true;
            Skip = skip;
            Take = take;

        }
    }
}
