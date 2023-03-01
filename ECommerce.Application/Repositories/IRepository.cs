using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories
{
    public interface IRepository<T>
    {
        Task<IList<T>> FindAll();
        Task<IList<T>> FindAllByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
    }
}
