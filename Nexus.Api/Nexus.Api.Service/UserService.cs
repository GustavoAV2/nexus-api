using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;
using Nexus.Api.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexus.Api.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserDb _userDb;
        private IConfiguration _configuration { get; }
        public UserService(ILogger<UserService> logger, IConfiguration configuration, UserDb userDb)
        {
            _logger = logger;
            _userDb = userDb;
            _configuration = configuration;
        }

        public async Task<User> CreateUser(User inputUser)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(inputUser.Password);

            var newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = inputUser.Email,
                Password = passwordHash,
                Name = inputUser.Name
            };
                
            _userDb.All.Add(newUser);
            await _userDb.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> GetUserById(string id)
        {
            var foundUser = await _userDb.All.FindAsync(id);
            return foundUser;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var foundUser = await _userDb.All.ToListAsync();
            return foundUser;
        }
    }
}
