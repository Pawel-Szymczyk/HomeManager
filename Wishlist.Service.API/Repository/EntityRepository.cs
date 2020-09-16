using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Service.API.DBContext;
using Wishlist.Service.API.Models;

namespace Wishlist.Service.API.Repository
{
    public class EntityRepository : IEntityRepository
    {
        private readonly WishlistContext _dbContext;

        public EntityRepository(WishlistContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public IEnumerable<Entity> GetEntities()
        {
            return _dbContext.Entities.Include(e => e.Occasion).ToList(); ;
        }

        public Entity GetEntityById(Guid id)
        {
            return _dbContext.Entities.Find(id);
        }

        public void InsertEntity(Entity model)
        {
            //model.Id = new Guid();
            model.CreateDate = DateTime.UtcNow;
            model.ModifyDate = DateTime.UtcNow;

            _dbContext.Add(model);
            Save();
        }

        public void UpdateEntity(Entity model)
        {
            _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void DeleteEntity(Guid id)
        {
            var entity = _dbContext.Entities.Find(id);
            _dbContext.Entities.Remove(entity);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
