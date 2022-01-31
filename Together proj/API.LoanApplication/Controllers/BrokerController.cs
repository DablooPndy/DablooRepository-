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
    public class BrokerController : ApiController
    {
        private readonly IBrokerLoanManager _brokerLoanManager = null;
        private readonly IMapper _mapper = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_brokerLoanManager"></param>
        /// <param name="_mapper"></param>
        public BrokerController(IBrokerLoanManager _brokerLoanManager, IMapper _mapper)
        {
            this._brokerLoanManager = _brokerLoanManager;
            this._mapper = _mapper;
        }

        /// <summary>
        /// Get All Loan Details 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        //[Authorize(Roles = "broker")]
        [ResponseType(typeof(List<LoanDetails>))]
        [Route("api/Broker/GetAllLoanDetails")]
        public IHttpActionResult GetAllLoanDetails()
        {
            var LoanDetailsList = _mapper.Map<List<LoanDetails>>(_brokerLoanManager.GetAllLoanDetails());

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
        //[Authorize(Roles = "broker")]
        [ResponseType(typeof(LoanDetails))]
        [Route("api/Broker/GetLoanDetailsByID")]
        public IHttpActionResult GetLoanDetailsByID(int LoanId)
        {
            if (LoanId > 0)
            {
                if (_brokerLoanManager.GetLoanDetailsByID(LoanId) == null)
                {
                    return Ok(HttpStatusCode.NotFound);
                }
                else
                {
                    return Ok(_mapper.Map<LoanDetails>(_brokerLoanManager.GetLoanDetailsByID(LoanId)));
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Insert Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "broker")]
        [ResponseType(typeof(bool))]
        [Route("api/Broker/InsertLoanDetails")]
        public IHttpActionResult InsertLoanDetails(LoanDetails _loanDetails)
        {
            return Ok(_brokerLoanManager.InsertLoanDetails(_mapper.Map<Model.LoanApplication.LoanDetails>(_loanDetails)));
        }

        /// <summary>
        /// Update Loan Details
        /// </summary>
        /// <param name="_loanDetails"></param>
        /// <returns></returns>
        [HttpPut]
        //[Authorize(Roles = "broker")]
        [ResponseType(typeof(bool))]
        [Route("api/Broker/UpdateLoanDetails")]
        public IHttpActionResult UpdateLoanDetails(LoanDetails _loanDetails)
        {
            return Ok(_brokerLoanManager.UpdateLoanDetails(_mapper.Map<Model.LoanApplication.LoanDetails>(_loanDetails)));
        }

        /// <summary>
        /// Delete Loan Details by Loan id
        /// </summary>
        /// <param name="LoanId"></param>
        /// <returns></returns>
        [HttpDelete]
        //[Authorize(Roles = "broker")]
        [ResponseType(typeof(bool))]
        [Route("api/Broker/DeleteLoanDetails")]
        public IHttpActionResult DeleteLoanDetails(int LoanId)
        {
            return Ok(_brokerLoanManager.DeleteLoanDetails(LoanId));
        }
    }
}
