﻿using System;
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
        private readonly IBrokerUOW _loanDetailsUOW = null;
        private readonly IMapper _mapper = null;

        public BrokerLoanManager(IBrokerUOW _loanDetailsUOW, IMapper _mapper)
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
            return _mapper.Map<List<LoanDetails>>(_loanDetailsUOW.GetAllDetails()).ToList();
        }

        /// <summary>
        /// Get Loan Details By Loanid
        /// </summary>
        /// <param name="LoanId"></param>
        /// <returns>LoanDetails</returns>
        public LoanDetails GetLoanDetailsByID(int LoanId)
        {
            return _mapper.Map<LoanDetails>(_loanDetailsUOW.GetDetailsByID(LoanId));
        }

        /// <summary>
        /// Insert Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        public void InsertLoanDetails(LoanDetails _loanDetails)
        {
            _loanDetailsUOW.Insert(_mapper.Map<Database.LoanApplication.Entities.LoanDetails>(_loanDetails));
        }

        /// <summary>
        /// Update Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        public void UpdateLoanDetails(LoanDetails _loanDetails)
        {
            _loanDetailsUOW.Update(_mapper.Map<Database.LoanApplication.Entities.LoanDetails>(_loanDetails));
        }

        /// <summary>
        /// Delete Loan Details by LoanId
        /// </summary>
        /// <param name="LoanId"></param>
        public void DeleteLoanDetails(int LoanId)
        {
            var Entity = _loanDetailsUOW.GetDetailsByID(LoanId);
            if (Entity != null)
            {
                Entity.IsDeleted = true;
                _loanDetailsUOW.Delete(Entity);
            }
        }
    }
}