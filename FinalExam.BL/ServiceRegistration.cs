using FinalExam.BL.Services;
using FinalExam.BL.Services.DepartmentService;
using FinalExam.BL.Services.DoctorService;
using Microsoft.Extensions.DependencyInjection;

namespace FinalExam.BL;

public static class ServiceRegistration
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceRegistration));
        return services;
    }
}
