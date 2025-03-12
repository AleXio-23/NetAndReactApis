using NorthernLight.Auth.Domain.Models.Dictionary.JobPositions;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Dictionary.JobPositions.GetJobPosition
{
    public interface IGetJobPositionService
    {
        Task<ServiceResult<JobPositionDTO>> Execute(int id, CancellationToken cancellationToken);
    }
}
