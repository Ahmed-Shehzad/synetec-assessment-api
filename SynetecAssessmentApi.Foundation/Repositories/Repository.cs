using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Foundation.Repositories.Interfaces;

namespace SynetecAssessmentApi.Foundation.Repositories
{
    public class Repository<TModel>: IRepository<TModel> where TModel: class
    {
        // ReSharper disable once MemberCanBePrivate.Global
        protected readonly DbContext Context;
        // ReSharper disable once MemberCanBePrivate.Global
        protected readonly DbSet<TModel> Set;

        public Repository(DbContext dbContext)
        {
            Context = dbContext ?? throw new ArgumentNullException();
            Set = dbContext.Set<TModel>();
        }

        public void Dispose()
        {
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<ICollection<TModel>> GetListAsync(bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            return await Queryable(enableTracking).ToListAsync(cancellationToken);
        }

        public IQueryable<TModel> Queryable(bool enableTracking = false)
        {
            return enableTracking ? Set : Set.AsNoTracking();
        }
    }
}