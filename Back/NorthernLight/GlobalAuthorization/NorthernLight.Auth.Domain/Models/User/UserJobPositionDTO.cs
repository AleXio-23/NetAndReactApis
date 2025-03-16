using NorthernLight.Auth.Domain.Models.Dictionary.Departments;
using NorthernLight.Auth.Domain.Models.Dictionary.JobPositions;

namespace NorthernLight.Auth.Domain.Models.User
{
    public class UserJobPositionDTO
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }

        public int? PositionId { get; set; }

        public int? DepartmentId { get; set; }
        public virtual DepartmentDTO? Department { get; set; }

        public virtual JobPositionDTO? Position { get; set; }

    }
}
