using FluentValidation;
using MediatR;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SynetecAssessmentApi.Foundation.Core.Extensions;
using SynetecAssessmentApi.Foundation.Core.Interfaces;
using SynetecAssessmentApi.Foundation.Repositories;
using SynetecAssessmentApi.Foundation.Repositories.Interfaces;
using SynetecAssessmentApi.Persistence;
using SynetecAssessmentApi.Persistence.Repositories;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;
using SynetecAssessmentApi.Services.Queries.Rewards;

namespace SynetecAssessmentApi.UnitTests.Mocks
{
    public class MockServices
    {
        /// Configure Service Collection for Test Environment
        public IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SynetecAssessmentApi", Version = "v1" });
            });
            services.AddFluentValidationRulesToSwagger();
            services.AddMediatRConfiguration();
            
            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<AppDbContext>((sp, options) =>
                {
                    options.UseInMemoryDatabase("HrDb").UseInternalServiceProvider(sp);
                });
            
            // Repositories
            // =========================================================================================================================================
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            // =========================================================================================================================================
            
            services.AddScoped<IBonusCalculator, BonusCalculator>();
            
            services.Scan(scan =>
            {
                scan.FromAssembliesOf(typeof(Services.SynetecAssessmentApi))
                    .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>))).AsImplementationOfInterface(typeof(IRequestHandler<,>)).WithScopedLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IMap<,>))).AsImplementationOfInterface(typeof(IMap<,>)).WithScopedLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>))).AsImplementationOfInterface(typeof(IValidator<>)).WithScopedLifetime();
            });
            return services;
        }
    }
}