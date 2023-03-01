using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public BaseRepository(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public async Task<IList<T>> FindAll() => await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            await RepositoryContext.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
        public async Task Create(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IList<T>> FindAllByCondition(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }
    }
}
