using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Platform.Helpers;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
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

                // Specific logic for PlatformUserModel
                if (model is PlatformUserModel user)
                {
                    // Encrypt the password before saving
                    var encryptionService = new UserPasswordEncryption(user.Password);
                    user.Password = encryptionService.HashPassword;
                }

                await Context.Set<TEntity>().AddAsync(model);
                await SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0}:{1} Message: {2} InnerException: {3}", nameof(ExecuteCreateAsync), typeof(TEntity).Name, ex.Message, ex.InnerException!);
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

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0}:{1} Message: {2} InnerException: {3}", nameof(ExecuteDeleteAsync), typeof(TEntity).Name, ex.Message, ex.InnerException!);
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0}:{1} Message: {2} InnerException: {3}", nameof(GetAllAsync), typeof(TEntity).Name, ex.Message, ex.InnerException!);
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
