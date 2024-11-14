using IlyaMatlashKt_42_21.Tests.laba1.Filters;
using laba1.Database;
using laba1.Filters;
using laba1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace laba1.Interfaces.WorkloadInterfaces
{
        public interface IWorkloadService
        {
        public Task<Workload> AddWorkloadAsync(Workload workload, CancellationToken cancellationToken);
        public Task<Workload[]> GetWorkloadByEducationSubjectForNumOfHourse(NumberOfHourseFilter filter, CancellationToken cancellationToken = default);
        public Task<Workload[]> GetWorkloadsByProfessorNameAsync(WorkloadFilterProfessor filter, CancellationToken cancellationToken);
    }
    public class WorkloadService : IWorkloadService
    {
        //private readonly MatlashDbContext _dbContext;
        private  MatlashDbContext _dbContext;
        public WorkloadService(MatlashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Workload[]> GetWorkloadsByProfessorNameAsync(WorkloadFilterProfessor filter, CancellationToken cancellationToken = default)
        {
            var workload = _dbContext.Set<Workload>()
                .Where(p =>
                    (p.Professor.FirstName == filter.FirstName) ||
                    (p.Professor.LastName == filter.LastName) ||
                    (p.Professor.MiddleName == filter.MiddleName)).ToArrayAsync(cancellationToken);

            return workload;
        }

        public async Task<Workload> AddWorkloadAsync(Workload workload, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(workload);

            await _dbContext.SaveChangesAsync();

            return workload;
        }

        public Task<Workload[]> GetWorkloadByEducationSubject(WorkloadFilterEdSub filter, CancellationToken cancellationToken = default)
        {
            var workload = _dbContext.Set<Workload>()
                .Where(e =>
                (e.EducationalSubject.Name == filter.Name)).ToArrayAsync(cancellationToken);

            return workload;
        }

        public Task<Workload[]> GetWorkloadByEducationSubjectForNumOfHourse(NumberOfHourseFilter filter, CancellationToken cancellationToken = default)
        {
            var workload = _dbContext.Set<Workload>()
            .Where(w => (w.NumberOfHours >= filter.minHours) && (w.NumberOfHours <= filter.maxHours))
            .ToArrayAsync(cancellationToken);

            return workload;
        }

    }
}
