using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.DataAccess.Repository
{
    public class GenericRepository<T, dbContext> : IGenericRepository<T, dbContext> where T : class where dbContext : DbContext
    {
        private readonly DbContext _dbContext = null;
        private readonly DbSet<T> dbSet = null;

        public GenericRepository(dbContext _dbContext)
        {
            this._dbContext = _dbContext;
            dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Update(T obj)
        {

            dbSet.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            dbSet.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
