using System;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Persistence;

namespace SynetecAssessmentApi.UnitTests.Mocks
{
    /// Cofigure Service Provider for Test Environment
    public class MockServiceProvider
    {
        protected IServiceProvider ServiceProvider { get; }
        public MockServiceProvider()
        {
            var services = new ServiceCollection();
            var mockServices = new MockServices().ConfigureServices(services);
            ServiceProvider = mockServices.BuildServiceProvider();
            var context = ServiceProvider.GetRequiredService<AppDbContext>();
            DbContextGenerator.SeedData(context);
        }
    }
}