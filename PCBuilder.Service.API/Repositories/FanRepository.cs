using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;

namespace PCBuilder.Service.API.Repositories
{
    public class FanRepository : Repository<Fan, PCBuilderContext>
    {
        public FanRepository(PCBuilderContext context) : base(context)
        {
        }
    }
}
