using Database.LoanApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.DataAccess.UnitOfWork
{
    public interface ILoanDetailsUOW : IUnitOfWork<LoanDBContext>
    {
         IQueryable<LoanDetails> GetAllDetails();
         LoanDetails GetDetailsByID(int id);
         bool Insert(LoanDetails loanDetails);
         bool Update(LoanDetails loanDetails);
         bool Delete(LoanDetails loanDetails);
    }
}
