using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Database.LoanApplication;
using Database.LoanApplication.DataAccess.UnitOfWork;
using Model.LoanApplication;


namespace BusinessLogic.LoanApplication
{
    public class BrokerLoanManager : IBrokerLoanManager
    {
        private readonly ILoanDetailsUOW _loanDetailsUOW = null;
        private readonly IMapper _mapper = null;

        public BrokerLoanManager(ILoanDetailsUOW _loanDetailsUOW, IMapper _mapper)
        {
            this._loanDetailsUOW = _loanDetailsUOW;
            this._mapper = _mapper;
        }

        /// <summary>
        /// Get All Loan Details
        /// </summary>
        /// <returns>List<ModelLoanDetails></returns>
        public List<LoanDetails> GetAllLoanDetails()
        {
            List<LoanDetails> loanDetails = _mapper.Map<List<LoanDetails>>(_loanDetailsUOW.GetAllDetails().Where(x => x.IsDeleted == false).OrderByDescending(o => o.CreatedDate).ToList());
            loanDetails.ForEach(s => s.LTV = Utility.GetCalculatedLTV(s.Amount, s.Valuation));
            return loanDetails;
        }

        /// <summary>
        /// Get Loan Details By Loanid
        /// </summary>
        /// <param name="LoanId"></param>
        /// <returns>LoanDetails</returns>
        public LoanDetails GetLoanDetailsByID(int LoanId)
        {
            LoanDetails loanDetails = _mapper.Map<LoanDetails>(_loanDetailsUOW.GetDetailsByID(LoanId));
            loanDetails.LTV = Utility.GetCalculatedLTV(loanDetails.Amount, loanDetails.Valuation);
            return loanDetails;
        }

        /// <summary>
        /// Insert Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        public bool InsertLoanDetails(LoanDetails _loanDetails)
        {
            _loanDetails.CreatedDate = DateTime.Now;
            return _loanDetailsUOW.Insert(_mapper.Map<Database.LoanApplication.Entities.LoanDetails>(_loanDetails));
        }

        /// <summary>
        /// Update Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        public bool UpdateLoanDetails(LoanDetails _loanDetails)
        {
            _loanDetails.ModifiedDate = DateTime.Now;
            return _loanDetailsUOW.Update(_mapper.Map<Database.LoanApplication.Entities.LoanDetails>(_loanDetails));
        }

        /// <summary>
        /// Delete Loan Details by LoanId
        /// </summary>
        /// <param name="LoanId"></param>
        public bool DeleteLoanDetails(int LoanId)
        {
            var Entity = _loanDetailsUOW.GetDetailsByID(LoanId);
            if (Entity != null)
            {
                Entity.IsDeleted = true;
                return _loanDetailsUOW.Delete(Entity);
            }
            return false;
        }
    }
}