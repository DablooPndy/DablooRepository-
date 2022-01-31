using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.LoanApplication;
using Database.LoanApplication;
using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace API.LoanApplication
{
    /// <summary>
    /// Automapper Configuration
    /// </summary>
    public static class AutomapperConfiguration
    {
        /// <summary>
        /// Load profiles to configure auto mapper
        /// </summary>
        /// <returns>Returns configuration  mapper</returns>
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Mapping.ContractToModelProfile());
                cfg.AddProfile(new Mapping.ModelToContractProfile());
                cfg.AddProfile(new BusinessLogic.LoanApplication.Mapping.EntitiesToModelProfile());
                cfg.AddProfile(new BusinessLogic.LoanApplication.Mapping.ModelToEntitiesProfile());
                cfg.AddProfile(new Database.LoanApplication.Mapping.EntitiesToModelProfileDB());
                cfg.AddProfile(new Database.LoanApplication.Mapping.ModelToEntitiesProfileDB());
            });
            return config.CreateMapper();
        }

    }
}