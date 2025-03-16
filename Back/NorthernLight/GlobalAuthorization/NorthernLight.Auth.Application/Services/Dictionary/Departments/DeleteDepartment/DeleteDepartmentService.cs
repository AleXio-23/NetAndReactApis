using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.GuardChecks;

namespace NorthernLight.Auth.Application.Services.Dictionary.Departments.DeleteDepartment
{
    public class DeleteDepartmentService(IRepository<Department> departmentRepository) : IDeleteDepartmentService
    {
        public async Task<ServiceResult<bool>> Execute(int id, CancellationToken cancellationToken)
        {
            Guard.IdValidation(id);
            var getDepartment = await departmentRepository.Get(id, cancellationToken).ConfigureAwait(false);
            Guard.RecordNotFoundCHeck(getDepartment);

            getDepartment!.IsActive = false;
            await departmentRepository.Update(getDepartment, cancellationToken).ConfigureAwait(false);

            return ServiceResult<bool>.SuccessResult(true);
        }
    }
}