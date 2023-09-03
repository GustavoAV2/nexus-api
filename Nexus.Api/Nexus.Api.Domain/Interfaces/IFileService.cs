using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Interfaces
{
    public interface IFileService
    {
        Task<File> CreateFile(File inputFile);
        Task<List<File>> GetRepoFilesByRepoId(string projectId);
        Task<List<File>> GetAllFiles();
    }
}
