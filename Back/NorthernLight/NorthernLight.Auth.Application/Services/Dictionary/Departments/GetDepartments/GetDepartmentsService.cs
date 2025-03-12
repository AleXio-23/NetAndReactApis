using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Domain.Models.Dictionary.Departments;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;

namespace NorthernLight.Auth.Application.Services.Dictionary.Departments.GetDepartments
{
    public class GetDepartmentsService(IRepository<Department> departmentRepository) : IGetDepartmentsService
    {
        public async Task<ServiceResult<List<DepartmentDTO>>> Execute(DepartmentFilter filter,
            CancellationToken cancellationToken)
        {
            var query = departmentRepository.GetAllAsQueryable();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }

            if (filter.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == filter.IsActive.Value);
            }

            var result = await query.Select(x => new DepartmentDTO()
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive
            }).ToListAsync(cancellationToken).ConfigureAwait(false);

            return ServiceResult<List<DepartmentDTO>>.SuccessResult(result ?? []);
        }
    }
}