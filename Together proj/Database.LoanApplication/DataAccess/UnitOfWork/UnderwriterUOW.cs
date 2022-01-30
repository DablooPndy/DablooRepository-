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
    public class UnderwriterUOW : UnitOfWork<DbContext>, IUnderwriterUOW
    {
        private readonly DbContext _context = null;
        private readonly IUnderwriterRepository _underwriterRepository = null;

        public UnderwriterUOW(DbContext _context, IUnderwriterRepository _underwriterRepository) : base(_context)
        {
            this._context = _context;
            this._underwriterRepository = _underwriterRepository;
        }
        public IQueryable<LoanDetails> GetAllDetails()
        {
            return _underwriterRepository.GetAll().Where(x => x.IsDeleted == false && x.UWStatus == "").OrderByDescending(o => o.CreatedDate);
        }

        public LoanDetails GetDetailsByID(int id)
        {
            return _underwriterRepository.GetByID(id);
        }

        public void Update(LoanDetails loanDetails)
        {
            loanDetails.CaseReviewedDate = DateTime.Now;
            _underwriterRepository.Update(loanDetails);
            Save();
        }
    }
}
