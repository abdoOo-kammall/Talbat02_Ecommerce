using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalbatCore.Entites;

namespace TalbatCore.Specifications
{
    public interface ISpecification <T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Cratiral { get; set; }

        public List<Expression<Func<T , object>>> Includes { get; set; }

        public Expression <Func<T , object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDece { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagainationEnable { get; set; }


    }
}
