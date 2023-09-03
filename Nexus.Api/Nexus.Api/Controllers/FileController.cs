using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;
using NexusFile = Nexus.Api.Domain.Entities.File;

namespace Nexus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;
        private readonly IFileService _fileService;

        public FileController(ILogger<FileController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        [HttpGet(Name = "GetFiles")]
        public async Task<List<NexusFile>> GetAllFiles()
        {
            return await _fileService.GetAllFiles();
        }


        [HttpPost("{projectId}", Name = "PostFile")]
        public async Task<NexusFile> CreateFile([FromForm] IFormFile file, string projectId)
        {
            return await _fileService.CreateFile(file, projectId);
        }
    }
}
