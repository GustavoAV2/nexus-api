using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Interfaces
{
    public interface IStarService
    {
        Task<Star> CreateStar(Star inputStar);
        Task<List<Star>> GetAllStars();
    }
}
