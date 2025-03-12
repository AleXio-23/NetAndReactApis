using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Domain.Models.Dictionary.JobPositions;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;

namespace NorthernLight.Auth.Application.Services.Dictionary.JobPositions.GetJobPositions
{
    public class GetJobPositionsService(IRepository<JobPosition> jobPositionRepository) : IGetJobPositionsService
    {
        public async Task<ServiceResult<List<JobPositionDTO>>> Execute(JobPositionFilter filter,
            CancellationToken cancellationToken)
        {
            var query = jobPositionRepository.GetAllAsQueryable();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }

            if (filter.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == filter.IsActive.Value);
            }

            var result = await query.Select(x => new JobPositionDTO()
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive
            }).ToListAsync(cancellationToken).ConfigureAwait(false);

            return ServiceResult<List<JobPositionDTO>>.SuccessResult(result ?? []);
        }
    }
}