using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace SynetecAssessmentApi.Foundation.Core.Extensions
{
    public static class MediatRServiceConfiguration
    {
        public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            ServiceRegistrar.AddRequiredServices(services, new MediatR.MediatRServiceConfiguration());
            return services;
        }
    }
}