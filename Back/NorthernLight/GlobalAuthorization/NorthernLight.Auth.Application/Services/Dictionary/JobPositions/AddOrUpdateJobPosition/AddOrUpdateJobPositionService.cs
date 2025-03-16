using AutoMapper;
using NorthernLight.Auth.Domain.Models.Dictionary.JobPositions;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.GuardChecks;

namespace NorthernLight.Auth.Application.Services.Dictionary.JobPositions.AddOrUpdateJobPosition
{
    public class AddOrUpdateJobPositionService(IMapper mapper, IRepository<JobPosition> jobPositionRepository)
        : IAddOrUpdateJobPositionService
    {
        public async Task<ServiceResult<JobPositionDTO>> Execute(JobPositionDTO jobPositionDto,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(jobPositionDto.Name))
                throw new ArgumentException("Job position name can't be null or empty");
            if (jobPositionDto.Id is null or < 1)
            {
                var newJobPosition = mapper.Map<JobPosition>(jobPositionDto);
                var addResult = await jobPositionRepository.Add(newJobPosition, cancellationToken)
                    .ConfigureAwait(false);
                var returnResult = mapper.Map<JobPositionDTO>(addResult);

                return ServiceResult<JobPositionDTO>.SuccessResult(returnResult);
            }
            else if (jobPositionDto.Id > 1)
            {
                var getJobPosition = await jobPositionRepository.Get(jobPositionDto.Id ?? -1, cancellationToken)
                    .ConfigureAwait(false);

                Guard.RecordNotFoundCHeck(getJobPosition);
                getJobPosition!.Name = jobPositionDto.Name;
                getJobPosition.IsActive = jobPositionDto.IsActive ?? true;

                var saveResult = await jobPositionRepository.Update(getJobPosition, cancellationToken)
                    .ConfigureAwait(false);
                var resultDto = mapper.Map<JobPositionDTO>(saveResult);

                return ServiceResult<JobPositionDTO>.SuccessResult(resultDto);
            }
            else
            {
                throw new Exception("Unexpected error occured");
            }
        }
    }
}