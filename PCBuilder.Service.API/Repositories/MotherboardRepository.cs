using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repository
{
    public class MotherboardRepository : Repository<Motherboard, PCBuilderContext>
    {
        public MotherboardRepository(PCBuilderContext context) : base(context)
        {
        }
    }
}
