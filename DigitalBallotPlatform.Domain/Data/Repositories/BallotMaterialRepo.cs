using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class BallotMaterialRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<BallotMaterialModel, ElectionDbContext>(context, logger), IBallotMaterialRepo
    {
        public async Task<bool> ExecuteUpdateAsync(BallotMaterialDTO ballotMaterialDTO)
        {
            try
            {
                BallotMaterialModel? ballotMaterial = await Context.BallotMaterials.AsNoTracking().FirstOrDefaultAsyncEF(b => b.Id == ballotMaterialDTO.Id);
                if (ballotMaterial == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                ballotMaterial = await BallotMaterialDTO.MapBallotMaterialModel(ballotMaterialDTO);

                Context.BallotMaterials.Update(ballotMaterial);
                await SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<BallotMaterialModel?> GetBallotMaterialByIdAsync(int id)
        {
            try
            {
                BallotMaterialModel? ballotmaterial = await Context.BallotMaterials.AsNoTracking().FirstOrDefaultAsyncEF(b => b.Id == id);

                if (ballotmaterial == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetBallotMaterialByIdAsync), this);
                    return null;
                }

                Logger.LogInformation("[INFO] {1} Message: Entity {0} query for Id: {2} was successfull", nameof(BallotMaterialModel), nameof(GetBallotMaterialByIdAsync), id);

                return ballotmaterial;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetBallotMaterialByIdAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
