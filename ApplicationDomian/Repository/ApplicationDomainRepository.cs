using ApplicationDomian.Models;
using ApplicationDomian.Repository.Contact;
using Microsoft.EntityFrameworkCore;

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
                await _context.SaveChangesAsync();
                if (save != null)
                    created = true;
                return created;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
