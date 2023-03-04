using ApplicationDomian.Models;
using ApplicationDomian.Repository.Contact;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ApplicationDomian.Repository
{
    public class ApplicationDomainRepository<TEntity> : IApplicationDomainRepository<TEntity> where TEntity : class
    {
        private readonly MyApplicationDbContext _context;
        public ApplicationDomainRepository(MyApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll<T>(Expression<Func<TEntity, bool>>? whereCondition = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null) where T : class
        {
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();
                if (includes != null)
                    query = includes(query);
                if (whereCondition != null)
                    query = query.Where(whereCondition);

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity?> GetById(Guid key)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Post(TEntity model)
        {
            try
            {
                bool created = false;
                var save = await _context.Set<TEntity>().AddAsync(model);
                if (save != null)
                    created = true;
                return created;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
