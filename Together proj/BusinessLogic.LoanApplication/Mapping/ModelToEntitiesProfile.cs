using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LoanApplication.Mapping
{
    public class ModelToEntitiesProfile : Profile
    {
        /// <summary>
        /// Map Model To Entities
        /// </summary>
        public ModelToEntitiesProfile()
        {
            CreateMap<Model.LoanApplication.LoanDetails, Database.LoanApplication.Entities.LoanDetails>();
        }
    }
}
