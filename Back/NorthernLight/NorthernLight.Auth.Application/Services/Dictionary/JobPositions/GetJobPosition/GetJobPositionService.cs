using AutoMapper;
using NorthernLight.Auth.Domain.Models.Dictionary.JobPositions;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.GuardChecks;

namespace NorthernLight.Auth.Application.Services.Dictionary.JobPositions.GetJobPosition
{
    public class GetJobPositionService(IMapper mapper, IRepository<JobPosition> jobPositionRepository)
        : IGetJobPositionService
    {
        public async Task<ServiceResult<JobPositionDTO>> Execute(int id, CancellationToken cancellationToken)
        {
            Guard.IdValidation(id);

            var getJobPosition = await jobPositionRepository.Get(id, cancellationToken).ConfigureAwait(false);

            Guard.RecordNotFoundCHeck(getJobPosition);

            var jobPositionDto = mapper.Map<JobPositionDTO>(getJobPosition);

            return ServiceResult<JobPositionDTO>.SuccessResult(jobPositionDto);
        }
    }
}