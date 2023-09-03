using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;
using Nexus.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusFile = Nexus.Api.Domain.Entities.File;

namespace Nexus.Api.Service
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly ProjectDb _projectDb;
        private readonly UserDb _userDb;
        private readonly FileDb _fileDb;
        private readonly IUserService _userService;
        private readonly string _storagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Nexus-FilesServer");

        public FileService(ILogger<FileService> logger, ProjectDb projectDb, UserDb userDb, FileDb fileDb, IUserService userService)
        {
            _logger = logger;
            _fileDb = fileDb;
            _userDb = userDb;
            _projectDb = projectDb;
            _userService = userService;
        }

        public async Task<NexusFile> CreateFile(IFormFile inputFile, string projectId)
        {
            var localFilePath = await CreateLocalFile(inputFile, projectId);
            var newFile = new NexusFile()
            {
                Id = Guid.NewGuid().ToString(),
                Name = inputFile.Name,
                Path= localFilePath,
                Size= (int)inputFile.Length,
                Type= inputFile.ContentType,
                ProjectId = projectId
            };

            _fileDb.File.Add(newFile);
            await _fileDb.SaveChangesAsync();
            return newFile;
        }

        public async Task<string> CreateLocalFile(IFormFile inputFile, string projectId)
        {
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(inputFile.FileName);
            var filePath = Path.Combine(_storagePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await inputFile.CopyToAsync(stream);
            }

            return filePath;
        }

        public async Task<List<NexusFile>> GetRepoFilesByRepoId(string projectId)
        {
            var foundFile = await _fileDb.File.Where(f => f.ProjectId == projectId).ToListAsync();

            if (foundFile == null)
            {
                throw new KeyNotFoundException();
            }

            return foundFile;
        }

        public async Task<List<NexusFile>> GetAllFiles()
        {
            var foundSkill = await _fileDb.All.ToListAsync();
            return foundSkill;
        }
    }
}
