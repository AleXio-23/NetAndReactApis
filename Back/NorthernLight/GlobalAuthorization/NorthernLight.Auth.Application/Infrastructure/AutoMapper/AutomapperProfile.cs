using AutoMapper;
using NorthernLight.Auth.Domain.Models.Dictionary.Departments;
using NorthernLight.Auth.Domain.Models.Dictionary.JobPositions;
using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Persistence.Entities;

namespace NorthernLight.Auth.Application.Infrastructure.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<JobPosition, JobPositionDTO>().ReverseMap();
            CreateMap<UserProfile, UserProfileDTO>().ReverseMap();

            CreateMap<UserJobPosition, UserJobPositionDTO>()
                .ForMember(dep => dep.Department, opt => opt.MapFrom(x => x.Department))
                .ForMember(pos => pos.Position, opt => opt.MapFrom(x => x.Position))
                .ReverseMap();
        }
    }
}