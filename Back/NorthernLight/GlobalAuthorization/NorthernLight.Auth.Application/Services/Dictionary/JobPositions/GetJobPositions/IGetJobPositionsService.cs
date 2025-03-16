using NorthernLight.Auth.Domain.Models.Dictionary.JobPositions;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Dictionary.JobPositions.GetJobPositions
{
    public interface IGetJobPositionsService
    {
        Task<ServiceResult<List<JobPositionDTO>>> Execute(JobPositionFilter filter, CancellationToken cancellationToken);
    }
}
