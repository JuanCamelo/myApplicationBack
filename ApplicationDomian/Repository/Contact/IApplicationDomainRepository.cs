using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ApplicationDomian.Repository.Contact
{
    public interface IApplicationDomainRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll<T>(Expression<Func<TEntity, bool>>? whereCondition = null,
                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null) where T : class;
        Task<TEntity?> GetById(Guid key);
        Task<bool> Post(TEntity model);

        Task Save();
    }
}
