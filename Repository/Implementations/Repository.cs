using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AppDbContext _db;
        public Repository(AppDbContext db) 
        { 
            _db = db;
        }
        public void Add(TEntity entity)
        {
           _db.Set<TEntity>().Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entity = _db.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<TEntity> Find(object id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return  await _db.Set<TEntity>().ToListAsync();
        }

        public void Remove(IEnumerable<TEntity> entity)
        {
            _db.Set<TEntity>().RemoveRange(entity);
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

     
    }
}
