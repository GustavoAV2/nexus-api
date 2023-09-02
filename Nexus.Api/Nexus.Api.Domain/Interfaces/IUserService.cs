using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User inputUser);
        Task<User> GetUserById(string id);
        Task<List<User>> GetAllUsers();
    }
}
