using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.DataAccess.Repository
{
    public interface IGenericRepository<T, dbContext> where T : class where dbContext : DbContext
    {
        IQueryable<T> GetAll();
        T GetByID(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
