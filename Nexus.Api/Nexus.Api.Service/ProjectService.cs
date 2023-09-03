using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;
using Nexus.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Service
{
    public class ProjectService : IProjectService
    {
        private readonly ILogger<ProjectService> _logger;
        private readonly ProjectDb _projectDb;
        private readonly UserDb _userDb;
        private readonly IUserService _userService;
        private IConfiguration _configuration { get; }
        public ProjectService(ILogger<ProjectService> logger, IConfiguration configuration, ProjectDb projectDb, UserDb userDb, IUserService userService)
        {
            _logger = logger;
            _userDb = userDb;
            _projectDb = projectDb;
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<Project> CreateProject(Project inputProject) 
        { 
            var project = new Project() 
            {
                Id = Guid.NewGuid().ToString(),
                Name = inputProject.Name,
                Description = inputProject.Description,
                UserId = inputProject.UserId,
                isPublic = inputProject.isPublic
            };

            _projectDb.Project.Add(project);
            await _projectDb.SaveChangesAsync();
            return project;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            var foundProjects = await _projectDb.All.ToListAsync();
            return foundProjects;
        }
    }
}
