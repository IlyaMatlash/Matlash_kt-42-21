using laba1.Database;
using laba1.Filters;
using laba1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace laba1.Interfaces.WorkloadInterfaces
{
        public interface IWorkloadService
        {
        public Task<Workload[]> GetWorkloadAsync(WorkloadFilter filter, CancellationToken cancellationToken);
        //public Task<Workload> UpdateWorkloadAsync(Workload workload, CancellationToken cancellationToken);
        //public Task<Professor> CreateProfessor(Professor professor, CancellationToken cancellationToken);
    }
    public class WorkloadService : IWorkloadService 
    {
        //private readonly MatlashDbContext _dbContext;
        private  MatlashDbContext _dbContext;
        public WorkloadService(MatlashDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Workload[]> GetWorkloadAsync(WorkloadFilter filter, CancellationToken cancellationToken = default)
        {
            var workloads = _dbContext.Set<Workload>().Where(w => w.ProfessorId == filter.professor_id).ToArrayAsync(cancellationToken); //Заменять w.ProfessorId и filter.professor_id на необходимые
            return workloads;
        }

        //public async Task<Professor> CreateProfessor(Professor professor, CancellationToken cancellationToken = default)
        //{
        //    _dbContext.Professors.Add(professor);
        //    await _dbContext.SaveChangesAsync();
        //    return professor;

        //}        
    }
}
