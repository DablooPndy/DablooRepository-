using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanApplication.Mapping
{
    public class ModelToEntitiesProfileDB : Profile
    {
        /// <summary>
        /// Map Model To Entities
        /// </summary>
        public ModelToEntitiesProfileDB()
        {
            CreateMap<Model.LoanApplication.LoanDetails, Entities.LoanDetails>();
        }
    }
}
