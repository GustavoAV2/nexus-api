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
    public class ChallengeService : IChallengeService
    {
        private readonly ILogger<ChallengeService> _logger;
        private readonly ChallengeDb _challengeDb;
        public ChallengeService(ILogger<ChallengeService> logger, ChallengeDb challengeDb)
        {
            _logger = logger;
            _challengeDb = challengeDb;
        }
        public async Task<Challenge> CreateChallenge(Challenge inputChallenge)
        {
            var newChallenge = new Challenge
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId= inputChallenge.CompanyId,
                Description= inputChallenge.Description
            };

            _challengeDb.All.Add(newChallenge);
            await _challengeDb.SaveChangesAsync();
            return newChallenge;
        }

        public async Task<List<Challenge>> GetAllChallenges()
        {
            var foundChallenge = await _challengeDb.All.ToListAsync();
            return foundChallenge;
        }
    }
}
