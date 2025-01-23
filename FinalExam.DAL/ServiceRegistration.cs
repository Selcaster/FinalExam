using FinalExam.Core.RepositoryInterfaces;
using FinalExam.DAL.RepositoryImplements;
using Microsoft.Extensions.DependencyInjection;

namespace FinalExam.DAL;

public static class ServiceRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        return services;
    }
}
