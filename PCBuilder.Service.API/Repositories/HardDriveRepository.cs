using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;

namespace PCBuilder.Service.API.Repository
{
    public class HardDriveRepository : Repository<HardDrive, PCBuilderContext>
    {
        public HardDriveRepository(PCBuilderContext context) : base(context)
        {
        }
    }
}
