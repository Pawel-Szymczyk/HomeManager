using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repository
{
    public interface IPCBuildRepository
    {
        Task<IEnumerable<PCBuild>> GetPCBuilds();
        Task<PCBuild> GetPCBuildsById(Guid id);
        Task InsertPCBuild(PCBuild model);
        Task DeletePCBuild(Guid id);
        Task UpdatePCBuild(PCBuild model);
        Task SaveAsync();
    }
}
