using Microsoft.EntityFrameworkCore;
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
    public class StarService : IStarService
    {
        private readonly ILogger<StarService> _logger;
        private readonly StarDb _starDb;
        public StarService(ILogger<StarService> logger, StarDb starDb)
        {
            _logger = logger;
            _starDb = starDb;
        }
        public async Task<Star> CreateStar(Star inputStar)
        {
            var newStar = new Star
            {
                Id = Guid.NewGuid().ToString(),
                ProjectId = inputStar.ProjectId,
                UserId = inputStar.UserId
            };

            _starDb.All.Add(newStar);
            await _starDb.SaveChangesAsync();
            return newStar;
        }

        public async Task<List<Star>> GetAllStars()
        {
            var foundStar = await _starDb.All.ToListAsync();
            return foundStar;
        }
    }
}
