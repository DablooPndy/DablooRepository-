using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.LoanApplication;

namespace BusinessLogic.LoanApplication
{
    public class LoginManager : ILoginManager
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_mapper"></param>
        public LoginManager(IMapper _mapper)
        {
            this._mapper = _mapper;
        }

        /// <summary>
        /// Validate UserId and Password
        /// </summary>
        /// <param name="_loginDetails"></param>
        /// <returns></returns>
        public LoginDetails ValidateUser(LoginDetails _loginDetails)
        {
            if ((_loginDetails.UserName == "Underwriter" && Utility.Decrypt(_loginDetails.Password) == "underwriter") || (_loginDetails.UserName == "Broker" && Utility.Decrypt(_loginDetails.Password) == "broker"))
            {
                _loginDetails.Roles = _loginDetails.UserName == "Underwriter" ? "Underwriter" : "Broker";
                _loginDetails.IsUserValid = true;
            }
            _loginDetails.Password = "";
            return _loginDetails;
        }
    }
}
