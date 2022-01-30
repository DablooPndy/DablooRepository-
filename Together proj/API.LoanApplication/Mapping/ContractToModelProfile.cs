using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BusinessLogic.LoanApplication;

namespace API.LoanApplication.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class ContractToModelProfile : Profile
    {
        /// <summary>
        /// Map Contract To Model
        /// </summary>
        public ContractToModelProfile()
        {
            CreateMap<Contract.LoanApplication.LoanDetails, Model.LoanApplication.LoanDetails> ();
            CreateMap<Contract.LoanApplication.LoginDetails, Model.LoanApplication.LoginDetails > ();
        }
    }
}