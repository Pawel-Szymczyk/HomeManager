using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repository
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext context;
        public Repository(TContext context)
        {
            this.context = context;
        }


        public async Task<TEntity> Add(TEntity model)
        {
            await this.context.AddAsync(model);
            await this.SaveAsync();
            return model;
        }

        public async Task<TEntity> Delete(Guid Id)
        {
            TEntity entity = await this.context.Set<TEntity>().FindAsync(Id);
            if (entity == null)
            {
                return entity;
            }

            this.context.Set<TEntity>().Remove(entity);
            await this.SaveAsync();

            return entity;
        }

        public virtual async Task<TEntity> Get(Guid Id)
        {
            return await this.context.Set<TEntity>().FindAsync(Id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await this.context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity model)
        {
            this.context.Entry(model).State = EntityState.Modified;
            await this.SaveAsync();
            return model;
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }

    }
}
