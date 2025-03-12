using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Dictionary.JobPositions.DeleteJobPosition
{
    public interface IDeleteJobPositionService
    {
        Task<ServiceResult<bool>> Execute(int id, CancellationToken cancellationToken);
    }
}
