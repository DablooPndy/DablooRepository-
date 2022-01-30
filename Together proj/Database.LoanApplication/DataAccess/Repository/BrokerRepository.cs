using Database.LoanApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.DataAccess.Repository
{
    public class BrokerRepository : GenericRepository<LoanDetails, DbContext>, IBrokerRepository
    {
        public BrokerRepository(DbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
