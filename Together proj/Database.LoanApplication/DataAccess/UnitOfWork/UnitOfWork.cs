using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.LoanApplication.DataAccess.Repository;
using Database.LoanApplication.Entities;

namespace Database.LoanApplication.DataAccess.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly DbContext _dbcontext = null;
        
        public UnitOfWork(T _dbcontext)
        {
            this._dbcontext = _dbcontext;
        }

        /// <summary>
        /// This Save() Method Implement DbContext Class SaveChanges method so whenever we do a transaction we need to
        /// call this Save() method so that it will make the changes in the database
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        /// <summary>
        /// The Dispose() method is used to free unmanaged resources like files, database connections etc. at any time.
        /// </summary>
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
