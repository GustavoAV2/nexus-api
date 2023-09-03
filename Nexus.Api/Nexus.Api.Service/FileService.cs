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
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly ProjectDb _projectDb;
        private readonly UserDb _userDb;
        private readonly FileDb _fileDb;
        private readonly IUserService _userService;
        private IConfiguration _configuration { get; }
        public FileService(ILogger<FileService> logger, IConfiguration configuration, ProjectDb projectDb, UserDb userDb, FileDb fileDb, IUserService userService)
        {
            _logger = logger;
            _fileDb = fileDb;
            _userDb = userDb;
            _projectDb = projectDb;
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<File> CreateFile(File inputFile)
        {
            var newFile = new File()
            {
                Id = Guid.NewGuid().ToString(),
                Name = inputFile.Name,
                Path= inputFile.Path,
                Size= inputFile.Size,
                Type= inputFile.Type,
                ProjectId = inputFile.ProjectId
            };

            _fileDb.File.Add(newFile);
            await _fileDb.SaveChangesAsync();
            return newFile;
        }

        public async Task<List<File>> GetRepoFilesByRepoId(string projectId)
        {
            var foundFile = await _fileDb.File.Where(f => f.ProjectId == projectId).ToListAsync();

            if (foundFile == null)
            {
                throw new KeyNotFoundException();
            }

            return foundFile;
        }

        public async Task<List<File>> GetAllFiles()
        {
            var foundSkill = await _fileDb.All.ToListAsync();
            return foundSkill;
        }
    }
}
