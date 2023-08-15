using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Find(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(IEnumerable<TEntity> entity);
        void Delete(object id);
        int SaveChanges();
    }
}
