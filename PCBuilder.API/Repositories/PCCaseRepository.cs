using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repositories
{
    public class PCCaseRepository : Repository<PCCase, PCBuilderContext>
    {
        public PCCaseRepository(PCBuilderContext context) : base(context)
        {
        }
    }
}
