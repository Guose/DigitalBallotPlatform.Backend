using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Platform.DTOs;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class RoleRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<RoleModel, ElectionDbContext>(context, logger), IRoleRepo
    {
        public async Task<bool> ExecuteUpdateAsync(RoleDTO roleDto)
        {
            try
            {
                RoleModel? role = await Context.Roles.AsNoTracking().FirstOrDefaultAsyncEF(r => r.Id == roleDto.Id);
                if (role == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                role = await RoleDTO.MapRoleModel(roleDto);

                Context.Roles.Update(role);
                await SaveAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} has been updated", nameof(RoleModel), nameof(ExecuteUpdateAsync));

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<RoleDTO?> GetRoleByIdAsync(int id)
        {
            try
            {
                RoleModel? role = await Context.Roles.AsNoTracking().FirstOrDefaultAsyncEF(r => r.Id == id);
                if (role == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetRoleByIdAsync), this);
                    return null;
                }

                Logger.LogInformation("[INFO] {1} Message: Entity {0} query for Id: {2} was successfull", nameof(RoleModel), nameof(GetRoleByIdAsync), id);

                return await RoleDTO.MapRoleDto(role);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetRoleByIdAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
