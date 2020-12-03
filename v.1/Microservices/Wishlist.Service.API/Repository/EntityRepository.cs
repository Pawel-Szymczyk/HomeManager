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
            var entities = _dbContext.Entities
                .Include(e => e.Occasion)
                .Include(e => e.Category)
                .Include(e => e.State)
                .ToList();

            return entities;
        }

        public Entity GetEntityById(Guid id)
        {
            var entity = _dbContext.Entities
                .Include(e => e.Occasion)
                .Include(e => e.Category)
                .Include(e => e.State).FirstOrDefault(e => e.Id == id);

            return entity;
        }

        public void InsertEntity(Entity model)
        {
            //model.CreatedDate = DateTime.UtcNow;
            //model.ModifiedDate = DateTime.UtcNow;

            _dbContext.Entry(model).State = EntityState.Added;
            Save();
        }

        public void UpdateEntity(Entity model)
        {
            //model.ModifiedDate = DateTime.UtcNow;

            _dbContext.Entry(model).State = EntityState.Modified;
            Save();
        }

        public void DeleteEntity(Guid id)
        {
            var entity = _dbContext.Entities.Find(id);
            //_dbContext.Entities.Remove(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
