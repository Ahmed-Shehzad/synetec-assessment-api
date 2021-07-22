using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Foundation.Repositories.Interfaces;

namespace SynetecAssessmentApi.Persistence.Repositories.Interfaces
{
    /// <summary>
    /// Service for Employee Repository
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByIdAsync(int id, bool enableTracking = false, CancellationToken cancellationToken = default);
    }
}