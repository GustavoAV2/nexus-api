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
    public class TagService : ITagService
    {
        private readonly ILogger<TagService> _logger;
        private readonly TagDb _tagDb;
        public TagService(ILogger<TagService> logger, TagDb tagDb)
        {
            _logger = logger;
            _tagDb = tagDb;
        }
        public async Task<Tag> CreateTag(Tag inputTag)
        {
            var newTag = new Tag
            {
                Id = Guid.NewGuid().ToString(),
                Name = inputTag.Name,
            };

            _tagDb.All.Add(newTag);
            await _tagDb.SaveChangesAsync();
            return newTag;
        }

        public async Task<List<Tag>> GetAllTags()
        {
            var foundTag = await _tagDb.All.ToListAsync();
            return foundTag;
        }
    }
}
