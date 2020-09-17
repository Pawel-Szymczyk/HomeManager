using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repository
{
    public interface IPCBuildRepository
    {
        IEnumerable<PCBuild> GetPCBuilds();
        PCBuild GetPCBuildsById(Guid id);
        void InsertPCBuild(PCBuild model);
        void DeletePCBuild(Guid id);
        void UpdatePCBuild(PCBuild model);
        void Save();
    }
}
