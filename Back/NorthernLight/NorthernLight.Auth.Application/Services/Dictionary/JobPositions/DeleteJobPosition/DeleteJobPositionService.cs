using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.GuardChecks;

namespace NorthernLight.Auth.Application.Services.Dictionary.JobPositions.DeleteJobPosition
{
    public class DeleteJobPositionService(IRepository<JobPosition> jobPositionRepository) : IDeleteJobPositionService
    {
        public async Task<ServiceResult<bool>> Execute(int id, CancellationToken cancellationToken)
        {
            Guard.IdValidation(id);
            var getJobPosition = await jobPositionRepository.Get(id, cancellationToken).ConfigureAwait(false);
            Guard.RecordNotFoundCHeck(getJobPosition);
            getJobPosition!.IsActive = false;
            await jobPositionRepository.Update(getJobPosition, cancellationToken).ConfigureAwait(false);

            return ServiceResult<bool>.SuccessResult(true);
        }
    }
}