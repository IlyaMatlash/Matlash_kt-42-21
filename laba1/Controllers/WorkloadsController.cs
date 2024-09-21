using laba1.Interfaces.WorkloadInterfaces;
using laba1.Models;
using laba1.Filters;
using Microsoft.AspNetCore.Mvc;
using laba1.Database;
using Microsoft.EntityFrameworkCore;
namespace laba1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkloadsController : ControllerBase
    {
        private readonly ILogger<WorkloadsController> _logger;
        private readonly IWorkloadService _workloadService;
        private readonly MatlashDbContext _dbContext;
        public WorkloadsController(MatlashDbContext dbContext, ILogger<WorkloadsController> logger, IWorkloadService workloadService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _workloadService = workloadService;
        }
        [HttpPost(Name = "AddWorkload")]
        public async Task<IActionResult> AddWorkloadAsync(WorkloadEducationalSubjectFilter filter, CancellationToken cancellationToken = default)
        {
            var resp = await _workloadService.AddWorkloadAsync(filter, cancellationToken);
            return Ok(resp);
        }
    }
}
