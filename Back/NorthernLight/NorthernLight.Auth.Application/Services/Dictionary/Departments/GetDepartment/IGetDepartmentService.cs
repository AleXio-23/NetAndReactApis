using NorthernLight.Auth.Domain.Models.Dictionary.Departments;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Dictionary.Departments.GetDepartment
{
    public interface IGetDepartmentService
    {
        Task<ServiceResult<DepartmentDTO>> Execute(int id, CancellationToken cancellationToken);
    }
}
