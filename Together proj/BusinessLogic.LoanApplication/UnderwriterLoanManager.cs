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

        private readonly IUnderwriterUOW _underwriterLoanUOW = null;
        private readonly IMapper _mapper = null;

        public UnderwriterLoanManager(IUnderwriterUOW _underwriterLoanUOW, IMapper _mapper)
        {
            this._underwriterLoanUOW = _underwriterLoanUOW;
            this._mapper = _mapper;
        }

        /// <summary>
        /// Get All Loan Details
        /// </summary>
        /// <returns>List<LoanDetails></returns>
        public List<Model.LoanApplication.LoanDetails> GetAllLoanDetails()
        {
            return _mapper.Map<List<Model.LoanApplication.LoanDetails>>(_underwriterLoanUOW.GetAllDetails()).ToList();
        }

        /// <summary>
        /// Get Loan Details By Loanid
        /// </summary>
        /// <param name="LoanId"></param>
        /// <returns>LoanDetails</returns>
        public Model.LoanApplication.LoanDetails GetLoanDetailsByID(int LoanId)
        {
            return _mapper.Map<Model.LoanApplication.LoanDetails>(_underwriterLoanUOW.GetDetailsByID(LoanId));
        }

        /// <summary>
        /// Update Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        public void UpdateLoanDetails(Model.LoanApplication.LoanDetails _loanDetails)
        {
            _underwriterLoanUOW.Update(_mapper.Map<Database.LoanApplication.Entities.LoanDetails>(_loanDetails));
        }
    }
}
