﻿using laba1.Database;
using laba1.Filters;
using laba1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace laba1.Interfaces.WorkloadInterfaces
{
        public interface IWorkloadService
        {
        //public Task<Professor[]> GetWorkloadAsync(WorkloadFilterProfessor filter, CancellationToken cancellationToken);
        public Task<Workload[]> GetWorkloadsByProfessorNameAsync(string firstName, string lastName, string middleName, CancellationToken cancellationToken);
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
        //public Task<Professor[]> GetWorkloadAsync(WorkloadFilterProfessor filter, CancellationToken cancellationToken = default)
        //{
        //    var professors = _dbContext.Set<Professor>().Where(w => (w.LastName == filter.LastName) || (w.FirstName == filter.FirstName) || (w.MiddleName == filter.MiddleName)).ToArrayAsync(cancellationToken); //Заменять w.ProfessorId и filter.professor_id на необходимые
        //    return professors;
        //}

        public async Task<Workload[]> GetWorkloadsByProfessorNameAsync(string firstName, string lastName, string middleName, CancellationToken cancellationToken = default)
        {
            var professor = await _dbContext.Set<Professor>()
                .FirstOrDefaultAsync(p =>
                    p.FirstName.Contains(firstName) ||
                    p.LastName.Contains(lastName) ||
                    p.MiddleName.Contains(middleName), cancellationToken);

            if (professor == null)
            {
                return Array.Empty<Workload>(); // Или выбросьте исключение
            }

            return await _dbContext.Workloads
                .Where(w => w.ProfessorId == professor.Id)
                .ToArrayAsync(cancellationToken);
        }

        //public async Task<Professor> CreateProfessor(Professor professor, CancellationToken cancellationToken = default)
        //{
        //    _dbContext.Professors.Add(professor);
        //    await _dbContext.SaveChangesAsync();
        //    return professor;

        //}        
    }
}
