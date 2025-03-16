using NorthernLight.Auth.Domain.Models.Dictionary.JobPositions;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Dictionary.JobPositions.AddOrUpdateJobPosition
{
    public interface IAddOrUpdateJobPositionService
    {
        Task<ServiceResult<JobPositionDTO>> Execute(JobPositionDTO jobPositionDto, CancellationToken cancellationToken);
    }
}
