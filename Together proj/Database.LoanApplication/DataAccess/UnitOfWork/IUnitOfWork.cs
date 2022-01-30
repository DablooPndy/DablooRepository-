using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.LoanApplication.DataAccess.Repository;
using Database.LoanApplication.Entities;

namespace Database.LoanApplication.DataAccess.UnitOfWork
{
    public interface IUnitOfWork<T> where T : DbContext,IDisposable
    {
        void Save();
    }
}
