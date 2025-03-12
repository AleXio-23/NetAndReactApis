using AutoMapper;
using NorthernLight.Auth.Domain.Models.Dictionary.Departments;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.GuardChecks;

namespace NorthernLight.Auth.Application.Services.Dictionary.Departments.AddOrUpdateDepartment
{
    public class AddOrUpdateDepartmentService(IMapper mapper, IRepository<Department> departmentRepository) : IAddOrUpdateDepartmentService
    {
        public async Task<ServiceResult<DepartmentDTO>> Execute(DepartmentDTO departmentDto, CancellationToken cancellationToken)
        {
            if (departmentDto.Id is null or < 1)
            {
                var newDepartment = mapper.Map<Department>(departmentDto);
                var addResult = await departmentRepository.Add(newDepartment, cancellationToken).ConfigureAwait(false);
                var returnResult = mapper.Map<DepartmentDTO>(addResult);

                return ServiceResult<DepartmentDTO>.SuccessResult(returnResult);
            }
            else
            {
                if (departmentDto.Id >= 1)
                {
                    var getDepartment = await departmentRepository.Get(departmentDto.Id ?? -1, cancellationToken).ConfigureAwait(false);

                    Guard.RecordNotFoundCHeck(getDepartment);

                    getDepartment!.Name = departmentDto.Name;
                    getDepartment.IsActive = departmentDto.IsActive ?? true;

                    var saveResult = await departmentRepository.Update(getDepartment, cancellationToken).ConfigureAwait(false);
                    var resultDto = mapper.Map<DepartmentDTO>(saveResult);

                    return ServiceResult<DepartmentDTO>.SuccessResult(resultDto);
                }
                throw new Exception("Unexpected error occured");
            }
        }
    }
}
