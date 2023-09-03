using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;
using Nexus.Api.Service;

namespace Nexus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpGet(Name = "GetProjects")]
        public async Task<List<Project>> GetAllProjects()
        {
            return await _projectService.GetAllProjects();
        }


        [HttpPost(Name = "PostProject")]
        public async Task<Project> CreateProject(Project project)
        {
            return await _projectService.CreateProject(project);
        }
    }
}