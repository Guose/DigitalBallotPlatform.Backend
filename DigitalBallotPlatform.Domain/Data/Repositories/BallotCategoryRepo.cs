using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class BallotCategoryRepo(BallotDbContext context, ILogger logger) : 
        GenericRepository<BallotCategoryDTO, BallotDbContext>(context, logger), IBallotCategoryRepo
    {
        public async Task<bool> ExecuteUpdateAsync(BallotCategoryDTO ballotCategoryDto)
        {
            try
            {
                BallotCategoryModel? ballotCategory = await Context.BallotCategories.FirstOrDefaultAsyncEF(b => b.Id == ballotCategoryDto.Id);
                if (ballotCategory == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                ballotCategory = await BallotCategoryDTO.MapBallotCategoryModel(ballotCategoryDto);

                Context.BallotCategories.Update(ballotCategory);
                await SaveAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} has been updated", nameof(BallotCategoryModel), nameof(ExecuteUpdateAsync));

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
                BallotCategoryModel? ballotCategory = await Context.BallotCategories.FirstOrDefaultAsyncEF(b => b.Id == id);

                if (ballotCategory == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetBallotCategoryByIdAsync), this);
                    return null;
                }

                Logger.LogInformation("[INFO] {1} Message: Entity {0} query for Id: {2} was successfull", nameof(BallotCategoryModel), nameof(GetBallotCategoryByIdAsync), id);

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
