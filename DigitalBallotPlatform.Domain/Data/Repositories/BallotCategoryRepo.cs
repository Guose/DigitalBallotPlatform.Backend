using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class BallotCategoryRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<BallotCategoryModel, ElectionDbContext>(context, logger), IBallotCategoryRepo
    {
        public async Task<bool> ExecuteUpdateAsync(BallotCategoryDTO ballotCategoryDto)
        {
            try
            {
                BallotCategoryModel? ballotCategory = await Context.BallotCategories.AsNoTracking().FirstOrDefaultAsyncEF(b => b.Id == ballotCategoryDto.Id);
                if (ballotCategory == null)
                {
                    Logger.LogWarning("{0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                ballotCategory = await BallotCategoryDTO.MapBallotCategoryModel(ballotCategoryDto);

                Context.BallotCategories.Update(ballotCategory);
                await SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<BallotCategoryDTO?> GetBallotCategoryByIdAsync(int id)
        {
            try
            {
                BallotCategoryModel? ballotCategory = await Context.BallotCategories.AsNoTracking().FirstOrDefaultAsyncEF(b => b.Id == id);

                if (ballotCategory == null)
                {
                    Logger.LogWarning("{0} {1} Entity could not be found in the database.", nameof(GetBallotCategoryByIdAsync), this);
                    return null;
                }

                return await BallotCategoryDTO.MapBallotCategoryDto(ballotCategory);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetBallotCategoryByIdAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
