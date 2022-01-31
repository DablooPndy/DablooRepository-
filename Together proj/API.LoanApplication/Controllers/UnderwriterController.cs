using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BusinessLogic.LoanApplication;
using Contract.LoanApplication;

namespace API.LoanApplication.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UnderwriterController : ApiController
    {
        private readonly IUnderwriterLoanManager _underwriterLoanManager = null;
        private readonly IMapper _mapper = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_underwriterLoanManager"></param>
        /// <param name="_mapper"></param>
        public UnderwriterController(IUnderwriterLoanManager _underwriterLoanManager, IMapper _mapper)
        {
            this._underwriterLoanManager = _underwriterLoanManager;
            this._mapper = _mapper;
        }

        /// <summary>
        /// Get All Loan Details 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        //[Authorize(Roles = "underwriter")]
        [ResponseType(typeof(List<LoanDetails>))]
        [Route("api/Underwriter/GetAllLoanDetails")]
        public IHttpActionResult GetAllLoanDetails()
        {
            var LoanDetailsList = _mapper.Map<List<LoanDetails>>(_underwriterLoanManager.GetAllLoanDetails());

            if (LoanDetailsList == null || LoanDetailsList.Count == 0)
                return Ok(HttpStatusCode.NotFound);
            else
                return Ok(LoanDetailsList);
        }

        /// <summary>
        /// Get Loan Details By Loan ID
        /// </summary>
        /// <param name="LoanId"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = "underwriter")]
        [ResponseType(typeof(LoanDetails))]
        [Route("api/Underwriter/GetLoanDetailsByID")]
        public IHttpActionResult GetLoanDetailsByID(int LoanId)
        {
            if (LoanId > 0)
            {
                if (_underwriterLoanManager.GetLoanDetailsByID(LoanId) == null)
                {
                    return Ok(HttpStatusCode.NotFound);
                }
                else
                {
                    return Ok(_mapper.Map<LoanDetails>(_underwriterLoanManager.GetLoanDetailsByID(LoanId)));
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Update Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        /// <returns></returns>
        [HttpPut]
        //[Authorize(Roles = "underwriter")]
        [ResponseType(typeof(bool))]
        [Route("api/Underwriter/UpdateLoanDetails")]
        public IHttpActionResult UpdateLoanDetails(LoanDetails _loanDetails)
        {
            return Ok(_underwriterLoanManager.UpdateLoanDetails(_mapper.Map<Model.LoanApplication.LoanDetails>(_loanDetails)));
        }
    }
}