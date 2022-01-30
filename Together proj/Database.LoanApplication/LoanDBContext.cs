using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.LoanApplication.Entities;

namespace Database.LoanApplication
{
    public class LoanDBContext : DbContext
    {
        public LoanDBContext() : base("LoanDBContext")
        {

        }
        public DbSet<LoanDetails> LoanApplicationLoanDetails { get; set; }
    }
}
