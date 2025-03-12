using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Dictionary.Departments.DeleteDepartment
{
    public interface IDeleteDepartmentService
    {
        Task<ServiceResult<bool>> Execute(int id, CancellationToken cancellationToken);
    }
}
