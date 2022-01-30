using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace API.LoanApplication.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelToContractProfile : Profile
    {
        /// <summary>
        /// Map Model To Contract
        /// </summary>
        public ModelToContractProfile()
        {
            CreateMap<Model.LoanApplication.LoanDetails, Contract.LoanApplication.LoanDetails>();
            CreateMap<Model.LoanApplication.LoginDetails, Contract.LoanApplication.LoginDetails>();
        }
    }
}