using DigitalBallotPlatform.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class GenericRepository<TEntity, TContext>(TContext context) : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext Context { get; } = context;

        public async Task<bool> ExecuteCreateAsync(TEntity model)
        {
            if (model == null)
            {
                return false;
            }

            await Context.Set<TEntity>().AddAsync(model);
            await SaveAsync();
            return true;
        }

        public async Task<bool> ExecuteDeleteAsync(TEntity model)
        {
            if (model == null)
            {
                return false;
            }

            Context.Set<TEntity>().Remove(model);
            await SaveAsync();
            return true;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public bool HasChanges()
        {
            return Context.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
