using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Foundation.Repositories.Interfaces
{
    public interface IRepository<TModel> : IDisposable where TModel: class
    {
        Task<ICollection<TModel>> GetListAsync(bool enableTracking = false, CancellationToken cancellationToken = default);
    }
}