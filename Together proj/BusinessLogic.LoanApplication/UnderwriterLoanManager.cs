using AutoMapper;
using Database.LoanApplication.DataAccess.UnitOfWork;
using Database.LoanApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.LoanApplication;

namespace BusinessLogic.LoanApplication
{
    public class UnderwriterLoanManager : IUnderwriterLoanManager
    {

        private readonly ILoanDetailsUOW _loanDetailsUOW = null;
        private readonly IMapper _mapper = null;

        public UnderwriterLoanManager(ILoanDetailsUOW _loanDetailsUOW, IMapper _mapper)
        {
            this._loanDetailsUOW = _loanDetailsUOW;
            this._mapper = _mapper;
        }

        /// <summary>
        /// Get All Loan Details
        /// </summary>
        /// <returns>List<LoanDetails></returns>
        public List<Model.LoanApplication.LoanDetails> GetAllLoanDetails()
        {
            List<Model.LoanApplication.LoanDetails> loanDetails = _mapper.Map<List<Model.LoanApplication.LoanDetails>>(_loanDetailsUOW.GetAllDetails().Where(x => x.IsDeleted == false && x.UWStatus == null).OrderByDescending(o => o.CreatedDate).ToList());
            loanDetails.ForEach(s => s.LTV = Utility.GetCalculatedLTV(s.Amount, s.Valuation));
            return loanDetails;
        }

        /// <summary>
        /// Get Loan Details By Loanid
        /// </summary>
        /// <param name="LoanId"></param>
        /// <returns>LoanDetails</returns>
        public Model.LoanApplication.LoanDetails GetLoanDetailsByID(int LoanId)
        {
            Model.LoanApplication.LoanDetails loanDetails = _mapper.Map<Model.LoanApplication.LoanDetails>(_loanDetailsUOW.GetDetailsByID(LoanId));
            loanDetails.LTV = Utility.GetCalculatedLTV(loanDetails.Amount, loanDetails.Valuation);
            return loanDetails;
        }

        /// <summary>
        /// Update Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        public bool UpdateLoanDetails(Model.LoanApplication.LoanDetails _loanDetails)
        {
            _loanDetails.CaseReviewedDate = DateTime.Now;
            return _loanDetailsUOW.Update(_mapper.Map<Database.LoanApplication.Entities.LoanDetails>(_loanDetails));
        }
    }
}
