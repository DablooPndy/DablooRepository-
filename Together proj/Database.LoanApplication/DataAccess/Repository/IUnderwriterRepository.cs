using Database.LoanApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.DataAccess.Repository
{
    public interface IUnderwriterRepository : IGenericRepository<LoanDetails, DbContext>
    {
    }
}
