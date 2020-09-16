using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Service.API.Models;

namespace Wishlist.Service.API.Repository
{
    public interface IEntityRepository
    {
        IEnumerable<Entity> GetEntities();
        Entity GetEntityById(Guid id);
        void InsertEntity(Entity model);
        void DeleteEntity(Guid id);
        void UpdateEntity(Entity model);
        void Save();
    }
}
