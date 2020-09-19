using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repositories
{
    internal interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid Id);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task<T> Delete(Guid Id);
        Task SaveAsync();
    }
}
