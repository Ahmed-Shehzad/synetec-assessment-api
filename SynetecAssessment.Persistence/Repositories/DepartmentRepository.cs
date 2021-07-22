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
    /// Department Repository
    /// </summary>
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Department> GetByIdAsync(int id, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            //load the details of the selected department using the Id
            return await Queryable(enableTracking).Where(e => e.Id == id)
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}