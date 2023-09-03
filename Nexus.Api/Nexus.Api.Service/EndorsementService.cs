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
    public class EndorsementService : IEndorsementService
    {
        private readonly ILogger<EndorsementService> _logger;
        private readonly EndorsementDb _endorsementDb;
        public EndorsementService(ILogger<EndorsementService> logger, EndorsementDb endorsementDb)
        {
            _logger = logger;
            _endorsementDb = endorsementDb;
        }
        public async Task<Endorsement> CreateEndorsement(Endorsement inputEndorsement)
        {
            var newEndorsement = new Endorsement
            {
                Id = Guid.NewGuid().ToString(),
                UserId = inputEndorsement.UserId,
                SkillId = inputEndorsement.SkillId
            };

            _endorsementDb.All.Add(newEndorsement);
            await _endorsementDb.SaveChangesAsync();
            return newEndorsement;
        }

        public async Task<List<Endorsement>> GetAllEndorsements()
        {
            var foundEndorsement = await _endorsementDb.All.ToListAsync();
            return foundEndorsement;
        }
    }
}
