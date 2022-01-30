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
    public class BrokerUOW : UnitOfWork<DbContext>, IBrokerUOW
    {
        private readonly DbContext _context = null;
        private readonly IBrokerRepository _loanDetailsRepository = null;

        public BrokerUOW(DbContext _context, IBrokerRepository _loanDetailsRepository) : base(_context)
        {
            this._context = _context; 
            this._loanDetailsRepository = _loanDetailsRepository;
        }
        public IQueryable<LoanDetails> GetAllDetails()
        {
            return _loanDetailsRepository.GetAll().Where(x => x.IsDeleted == false).OrderByDescending(o => o.CreatedDate);
        }

        public LoanDetails GetDetailsByID(int id)
        {
            return _loanDetailsRepository.GetByID(id);
        }

        public void Insert(LoanDetails loanDetails)
        {
            loanDetails.CreatedDate = DateTime.Now;
            _loanDetailsRepository.Insert(loanDetails);
            Save();
        }

        public void Update(LoanDetails loanDetails)
        {
            loanDetails.ModifiedDate = DateTime.Now;
            _loanDetailsRepository.Update(loanDetails);
            Save();
        }

        public void Delete(LoanDetails loanDetails)
        {
            _loanDetailsRepository.Delete(loanDetails);
            Save();
        }
    }
}
