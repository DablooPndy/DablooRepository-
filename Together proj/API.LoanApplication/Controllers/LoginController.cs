using System;
using System.Collections.Generic;
using System.Linq;
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
    public class LoginController : ApiController
    {
        private readonly ILoginManager _loginManager = null;
        private readonly IMapper _mapper = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_loginManager"></param>
        /// <param name="_mapper"></param>
        public LoginController(ILoginManager _loginManager, IMapper _mapper)
        {
            this._loginManager = _loginManager;
            this._mapper = _mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_loginDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(LoginDetails))]
        [Route("api/NewLoginController/ValidateUser")]
        public IHttpActionResult ValidateUser(LoginDetails _loginDetails)
        {
            if (_loginManager.ValidateUser(_mapper.Map<Model.LoanApplication.LoginDetails>(_loginDetails)))
            { return Ok(); }
            else { return BadRequest(); };
        }
    }
}