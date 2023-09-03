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
    public class UserRelationService : IUserRelationService
    {
        private readonly ILogger<UserRelationService> _logger;
        private readonly UserRelationDb _userRelationDb;
        public UserRelationService(ILogger<UserRelationService> logger, UserRelationDb userRelationDb)
        {
            _logger = logger;
            _userRelationDb = userRelationDb;
        }
        public async Task<UserRelation> CreateUserRelation(UserRelation inputUserRelation)
        {
            var newUserRelation = new UserRelation
            {
                Id = Guid.NewGuid().ToString(),
                FollowedUserId = inputUserRelation.FollowedUserId,
                FollowingUserId = inputUserRelation.FollowingUserId
            };

            _userRelationDb.All.Add(newUserRelation);
            await _userRelationDb.SaveChangesAsync();
            return newUserRelation;
        }

        public async Task<List<UserRelation>> GetAllUserRelations()
        {
            var foundUserRelation = await _userRelationDb.All.ToListAsync();
            return foundUserRelation;
        }
    }
}
