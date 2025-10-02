using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalbatCore.Entites;
using TalbatCore.Specifications;

namespace TalbatCore.RepositoryContract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllwithSpecAsync(ISpecification<T> spec);
        Task<T> GetwithSpecAsync(ISpecification<T> spec);


    }
}
