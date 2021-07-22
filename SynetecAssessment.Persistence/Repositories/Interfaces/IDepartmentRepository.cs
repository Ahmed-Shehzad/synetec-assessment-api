using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Foundation.Repositories.Interfaces;

namespace SynetecAssessmentApi.Persistence.Repositories.Interfaces
{
    /// <summary>
    /// Service for Department Repository
    /// </summary>
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> GetByIdAsync(int id, bool enableTracking = false, CancellationToken cancellationToken = default);
    }
}