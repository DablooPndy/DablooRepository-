using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.LoanApplication;

namespace BusinessLogic.LoanApplication
{
    public interface IUnderwriterLoanManager
    {
        List<LoanDetails> GetAllLoanDetails();

        LoanDetails GetLoanDetailsByID(int id);

        void UpdateLoanDetails(LoanDetails _loanDetails);
    }
}
