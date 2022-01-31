using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.LoanApplication;

namespace BusinessLogic.LoanApplication
{
    public interface IBrokerLoanManager
    {
        List<LoanDetails> GetAllLoanDetails();

        LoanDetails GetLoanDetailsByID(int id);

        bool InsertLoanDetails(LoanDetails _loanDetails);

        bool UpdateLoanDetails(LoanDetails _loanDetails);

        bool DeleteLoanDetails(int id);
    }
}
