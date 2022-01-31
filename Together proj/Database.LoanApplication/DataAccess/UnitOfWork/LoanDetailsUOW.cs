using Database.LoanApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.LoanApplication.DataAccess.Repository;

namespace Database.LoanApplication.DataAccess.UnitOfWork
{
    public class LoanDetailsUOW : UnitOfWork<DbContext>, ILoanDetailsUOW
    {
        private readonly DbContext _context = null;
        private readonly ILoanDetailsRepository _loanDetailsRepository = null;

        public LoanDetailsUOW(DbContext _context, ILoanDetailsRepository _loanDetailsRepository) : base(_context)
        {
            this._context = _context; 
            this._loanDetailsRepository = _loanDetailsRepository;
        }
        public IQueryable<LoanDetails> GetAllDetails()
        {
            return _loanDetailsRepository.GetAll();
        }

        public LoanDetails GetDetailsByID(int id)
        {
            return _loanDetailsRepository.GetByID(id);
        }

        public bool Insert(LoanDetails loanDetails)
        {
            _loanDetailsRepository.Insert(loanDetails);
            Save();
            return true;
        }

        public bool Update(LoanDetails loanDetails)
        {
            _loanDetailsRepository.Update(loanDetails);
            Save();
            return true;
        }

        public bool Delete(LoanDetails loanDetails)
        {
            _loanDetailsRepository.Delete(loanDetails);
            Save();
            return true;
        }
    }
}
