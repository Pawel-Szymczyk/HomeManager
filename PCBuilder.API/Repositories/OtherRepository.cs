using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repositories
{
    public class OtherRepository : Repository<Other, PCBuilderContext>
    {
        public OtherRepository(PCBuilderContext context) : base(context) 
        { 
        }
    }
}
