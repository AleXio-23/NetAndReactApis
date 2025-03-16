using NorthernLight.Auth.Domain.Models.Dictionary.Departments;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Dictionary.Departments.GetDepartments
{
    public interface IGetDepartmentsService
    {
        Task<ServiceResult<List<DepartmentDTO>>> Execute(DepartmentFilter filter, CancellationToken cancellationToken);
    }
}
