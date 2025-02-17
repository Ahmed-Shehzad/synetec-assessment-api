using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using SynetecAssessmentApi.Foundation.Core.Extensions;
using SynetecAssessmentApi.Foundation.Core.Interfaces;
using SynetecAssessmentApi.Foundation.Repositories;
using SynetecAssessmentApi.Foundation.Repositories.Interfaces;
using SynetecAssessmentApi.Persistence;
using SynetecAssessmentApi.Persistence.Repositories;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;
using SynetecAssessmentApi.Services.Queries.Rewards;

namespace SynetecAssessmentApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        private IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SynetecAssessmentApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
