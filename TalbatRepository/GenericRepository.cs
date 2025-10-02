using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalbatCore.Entites;
using TalbatCore.RepositoryContract;
using TalbatCore.Specifications;
using TalbatRepository.Data;

namespace TalbatRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

     

        public async Task<IEnumerable<T>> GetAllwithSpecAsync(ISpecification<T> spec)
        {
            return await SpecificationEvaluation<T>.GetQuery(_dbContext.Set<T>() , spec).ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetwithSpecAsync(ISpecification<T> spec)
        {
            return await SpecificationEvaluation<T>.GetQuery(_dbContext.Set<T>(), spec).FirstOrDefaultAsync();
        }
    }
}
