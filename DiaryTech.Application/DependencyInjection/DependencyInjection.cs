using DiaryTech.Application.Mapping;
using DiaryTech.Application.Services;
using DiaryTech.Application.Validations;
using DiaryTech.Application.Validations.FluentValidations;
using DiaryTech.Domain.Dto.Report;
using DiaryTech.Domain.Interfaces.Services;
using DiaryTech.Domain.Interfaces.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DiaryTech.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ReportMapping));
        
        InitServices(services);
    }

    private static void InitServices(this IServiceCollection services)
    {
        services.AddScoped<IReportValidator, ReportValidator>();
        services.AddScoped<IValidator<CreateReportDto>, CreateReportValidator>();
        services.AddScoped<IValidator<UpdateReportDto>, UpdateReportValidator>();

        services.AddScoped<IReportService, ReportService>();
    }
}