//using Microsoft.EntityFrameworkCore;
//using NLog.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using laba1.Database;
//using laba1.Interfaces.WorkloadInterfaces;
//using laba1.Models;

//namespace IlyaMatlashKt_42_21.Tests
//{
//    public class WorkloadIntegrationTests
//    {
//        public readonly DbContextOptions<MatlashDbContext> _dbContextOptions;
//        public WorkloadIntegrationTests()
//        {
//            _dbContextOptions = new DbContextOptionsBuilder<MatlashDbContext>()
//            .UseInMemoryDatabase(databaseName: "project_practice")
//            .Options;
//        }
//        [Fact]
//        public async Task AddWorkloadsAsync_workloadObject_Test()
//        {

//            var ctx = new MatlashDbContext(_dbContextOptions);
//            var workloadService = new WorkloadService(ctx);
//            var professors = new List<Professor>
//            {
//                new Professor
//                {
//                    LastName = "Матлаш",
//                    FirstName = "Илья",
//                    MiddleName = "Федорович"
//                },
//                new Professor
//                {
//                    LastName = "Смирнов",
//                    FirstName = "Александр",
//                    MiddleName = "Павлович"
//                },
//            };
//            await ctx.Set<Professor>().AddRangeAsync(professors);
//            var educationalsubjects = new List<EducationalSubject>
//            {
//                new EducationalSubject
//                {
//                    Name = "Программирование"
//                },
//                new EducationalSubject
//                {
//                    Name = "Алгебра и геометрия"
//                },
//            };
//            await ctx.Set<EducationalSubject>().AddRangeAsync(educationalsubjects);
//            var workloads = new List<Workload>
//            {
//                new Workload
//                {
//                    ProfessorId = 1,
//                    EducationalSubjectId = 1,
//                    NumberOfHours = 10
//                },
//                new Workload
//                {
//                    ProfessorId = 1,
//                    EducationalSubjectId = 2,
//                    NumberOfHours = 20
//                },
//                new Workload
//                {
//                    ProfessorId = 2,
//                    EducationalSubjectId = 2,
//                    NumberOfHours = 30
//                }
//            };
//            await ctx.Set<Workload>().AddRangeAsync(workloads);
//            await ctx.SaveChangesAsync();
//            var workload = new Workload
//            {
//                ProfessorId = 1,
//                EducationalSubjectId = 1,
//                NumberOfHours = 40
//            };
//            var workloadResult = await workloadService.AddWorkloadAsync(workload, CancellationToken.None);

//            Assert.Equal(4, workloadResult.Id);
//            Assert.Equal(1, workloadResult.ProfessorId);
//            Assert.Equal(1, workloadResult.EducationalSubjectId);
//            Assert.Equal(40, workloadResult.NumberOfHours);
//        }
//    }
//}
