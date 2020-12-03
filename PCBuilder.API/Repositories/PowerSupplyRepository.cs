using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;

namespace PCBuilder.Service.API.Repositories
{
    public class PowerSupplyRepository : Repository<PowerSupply, PCBuilderContext>
    {
        public PowerSupplyRepository(PCBuilderContext context) : base(context)
        {
        }
    }
}
