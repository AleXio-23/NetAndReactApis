using NorthernLight.Auth.Domain.Models.Dictionary.Departments;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Dictionary.Departments.AddOrUpdateDepartment
{
    public interface IAddOrUpdateDepartmentService
    {
        Task<ServiceResult<DepartmentDTO>> Execute(DepartmentDTO departmentDto, CancellationToken cancellationToken);
    }
}
