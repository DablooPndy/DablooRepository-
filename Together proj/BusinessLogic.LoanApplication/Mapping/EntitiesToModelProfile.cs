using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LoanApplication.Mapping
{
    public class EntitiesToModelProfile : Profile
    {
        /// <summary>
        /// Map Entities To Model
        /// </summary>
        public EntitiesToModelProfile()
        {
            CreateMap<Database.LoanApplication.Entities.LoanDetails,Model.LoanApplication.LoanDetails>();
        }
    }
}
