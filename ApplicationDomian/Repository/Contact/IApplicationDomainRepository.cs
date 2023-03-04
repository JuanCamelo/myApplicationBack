namespace ApplicationDomian.Repository.Contact
{
    public interface IApplicationDomainRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(Guid key);
        Task<bool> Post(TEntity model);
    }
}
