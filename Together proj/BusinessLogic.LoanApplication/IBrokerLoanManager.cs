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

        void InsertLoanDetails(LoanDetails _loanDetails);

        void UpdateLoanDetails(LoanDetails _loanDetails);

        void DeleteLoanDetails(int id);
    }
}
