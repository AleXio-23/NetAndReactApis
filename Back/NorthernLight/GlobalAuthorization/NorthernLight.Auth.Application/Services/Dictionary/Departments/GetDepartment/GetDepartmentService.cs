using AutoMapper;
using NorthernLight.Auth.Domain.Models.Dictionary.Departments;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.GuardChecks;

namespace NorthernLight.Auth.Application.Services.Dictionary.Departments.GetDepartment
{
    public class GetDepartmentService(IRepository<Department> departmentRepository, IMapper mapper)
        : IGetDepartmentService
    {
        public async Task<ServiceResult<DepartmentDTO>> Execute(int id, CancellationToken cancellationToken)
        {
            Guard.IdValidation(id);

            var getDepartment = await departmentRepository.Get(id, cancellationToken).ConfigureAwait(false);
            Guard.RecordNotFoundCHeck(getDepartment);

            var departmentDto = mapper.Map<DepartmentDTO>(getDepartment);

            return ServiceResult<DepartmentDTO>.SuccessResult(departmentDto);
        }
    }
}