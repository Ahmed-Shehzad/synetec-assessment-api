using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Foundation.Repositories;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    /// <summary>
    /// Employee Repository
    /// </summary>
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Employee> GetByIdAsync(int id, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            //load the details of the selected employee using the Id
            return await Queryable(enableTracking).Where(e => e.Id == id)
                .Include(e => e.Department)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}