using Database.LoanApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.DataAccess.Repository
{
    public class LoanDetailsRepository : GenericRepository<LoanDetails, DbContext>, ILoanDetailsRepository
    {
        public LoanDetailsRepository(DbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
