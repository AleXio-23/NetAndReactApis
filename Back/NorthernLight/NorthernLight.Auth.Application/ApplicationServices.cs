using Microsoft.Extensions.DependencyInjection;
using NorthernLight.Auth.Application.Models.FluentValidation;
using NorthernLight.Auth.Application.Services.Auth.ChangePassword;
using NorthernLight.Auth.Application.Services.Auth.GoogleLogIn;
using NorthernLight.Auth.Application.Services.Auth.LogIn;
using NorthernLight.Auth.Application.Services.Auth.Register;
using NorthernLight.Auth.Application.Services.Auth.ResetPassword;
using NorthernLight.Auth.Application.Services.Dictionary.Departments.AddOrUpdateDepartment;
using NorthernLight.Auth.Application.Services.Dictionary.Departments.DeleteDepartment;
using NorthernLight.Auth.Application.Services.Dictionary.Departments.GetDepartment;
using NorthernLight.Auth.Application.Services.Dictionary.Departments.GetDepartments;
using NorthernLight.Auth.Application.Services.Dictionary.JobPositions.AddOrUpdateJobPosition;
using NorthernLight.Auth.Application.Services.Dictionary.JobPositions.DeleteJobPosition;
using NorthernLight.Auth.Application.Services.Dictionary.JobPositions.GetJobPosition;
using NorthernLight.Auth.Application.Services.Dictionary.JobPositions.GetJobPositions;
using NorthernLight.Auth.Application.Services.Users.User.ActivateOrDeactivateUser;
using NorthernLight.Auth.Application.Services.Users.User.GetUser;
using NorthernLight.Auth.Application.Services.Users.User.GetUsers;
using NorthernLight.Auth.Application.Services.Users.UserProfile.AddOrUpdateProfile;

namespace NorthernLight.Auth.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<RegisterDtoValidator>();
            services.AddScoped<ILogInService, LogInService>();


            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<IAddOrUpdateProfileService, AddOrUpdateProfileService>();
            services.AddScoped<IActivateOrDeactivateUserService, ActivateOrDeactivateUserService>();

            services.AddScoped<IGetDepartmentsService, GetDepartmentsService>();
            services.AddScoped<IGetDepartmentService, GetDepartmentService>();
            services.AddScoped<IDeleteDepartmentService, DeleteDepartmentService>();
            services.AddScoped<IAddOrUpdateDepartmentService, AddOrUpdateDepartmentService>();
            services.AddScoped<IAddOrUpdateJobPositionService, AddOrUpdateJobPositionService>();
            services.AddScoped<IDeleteJobPositionService, DeleteJobPositionService>();
            services.AddScoped<IGetJobPositionService, GetJobPositionService>();
            services.AddScoped<IGetJobPositionsService, GetJobPositionsService>();

            services.AddScoped<IGoogleLogInService, GoogleLogInService>();
            services.AddScoped<IResetPasswordService, ResetPasswordService>();
            services.AddScoped<IChangePasswordRequestService, ChangePasswordRequestService>();

            return services;
        }
    }
}
