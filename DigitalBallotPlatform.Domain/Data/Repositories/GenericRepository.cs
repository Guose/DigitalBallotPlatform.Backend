using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class GenericRepository<TEntity, TContext>(TContext context, ILogger logger) : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext Context { get; } = context;
        protected ILogger Logger { get; } = logger;

        public async Task<bool> ExecuteCreateAsync(TEntity model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }

                await Context.Set<TEntity>().AddAsync(model);
                await SaveAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} has been created", typeof(TEntity).Name, nameof(ExecuteCreateAsync));

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {3}:{2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteCreateAsync), typeof(TEntity).Name);
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> ExecuteDeleteAsync(TEntity model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }

                Context.Set<TEntity>().Remove(model);
                await SaveAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} has been deleted", typeof(TEntity).Name, nameof(ExecuteDeleteAsync));

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {3}:{2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteDeleteAsync), typeof(TEntity).Name);
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var entity = await Context.Set<TEntity>().ToListAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} query for all records was successfull", typeof(TEntity).Name, nameof(GetAllAsync));

                return entity;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {3}:{2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetAllAsync), typeof(TEntity).Name);
                throw new ArgumentException(ex.Message);
            }
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
