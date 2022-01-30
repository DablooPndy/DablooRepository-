using Database.LoanApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.DataAccess.UnitOfWork
{
    public interface IBrokerUOW : IUnitOfWork<LoanDBContext>
    {
         IQueryable<LoanDetails> GetAllDetails();
         LoanDetails GetDetailsByID(int id);
         void Insert(LoanDetails loanDetails);
         void Update(LoanDetails loanDetails);
         void Delete(LoanDetails loanDetails);
    }
}
