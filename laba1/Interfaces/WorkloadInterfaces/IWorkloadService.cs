using laba1.Database;
using laba1.Filters;
using laba1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace laba1.Interfaces.WorkloadInterfaces
{
        public interface IWorkloadService
        {
        public Task<Workload[]> AddWorkloadAsync(WorkloadEducationalSubjectFilter filter, CancellationToken cancellationToken);
        }
    public class WorkloadService : IWorkloadService 
    {
        private readonly MatlashDbContext _dbContext;
        public WorkloadService(MatlashDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Workload[]> AddWorkloadAsync(WorkloadEducationalSubjectFilter filter, CancellationToken cancellationToken = default)
        {
            var workloads = _dbContext.Set<Workload>().Where(w => w.EducationalSubjectId == filter.Id).ToArrayAsync(cancellationToken);
            return workloads;
        }

    }
}
