using DiaryTech.Application.DependencyInjection;
using DiaryTech.DAL.DependencyInjection;
using DiaryTech.Domain.Settings;
using DiaryTech.WebApi;
using DiaryTech.WebApi.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.DefaultSection));

builder.Services.AddControllers();

builder.Services.AddAuthenticationAndAuthorization(builder);
builder.Services.AddSwagger();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiaryTech Swagger v1.0");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "DiaryTech Swagger v2.0");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
