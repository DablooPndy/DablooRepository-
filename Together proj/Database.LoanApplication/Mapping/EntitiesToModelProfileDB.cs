using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.Mapping
{
    public class EntitiesToModelProfileDB : Profile
    {
        /// <summary>
        /// Map Entities To Model
        /// </summary>
        public EntitiesToModelProfileDB()
        {
            CreateMap<Entities.LoanDetails,Model.LoanApplication.LoanDetails>();
        }
    }
}
