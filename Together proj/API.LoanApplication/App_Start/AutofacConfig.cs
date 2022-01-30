using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.LoanApplication;
using Database.LoanApplication;
using Database.LoanApplication.DataAccess.Repository;
using Database.LoanApplication.DataAccess.UnitOfWork;
using Autofac;
using System.Diagnostics.CodeAnalysis;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

namespace API.LoanApplication
{
    /// <summary>
    /// Autofac Configuration class
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// Method for Register Dependencies
        /// </summary>
        public static void RegisterDependencies()
        {
            SetupAutofacContainer();
        }

        /// <summary>
        /// Register all Dependencies and configure the Dependency Resolver
        /// </summary>
        public static void SetupAutofacContainer()
        {
            /// <summary>
            /// Create Container
            /// </summary>
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;
            // Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static void  RegisterServices(ContainerBuilder builder)
        {
            // Register Database Layer.
            builder.RegisterType<BrokerRepository>().As<IBrokerRepository>().InstancePerRequest();
            builder.RegisterType<UnderwriterRepository>().As<IUnderwriterRepository>().InstancePerRequest();
            builder.RegisterType<BrokerUOW>().As<IBrokerUOW>().InstancePerRequest();
            builder.RegisterType<UnderwriterUOW>().As<IUnderwriterUOW>().InstancePerRequest();
            builder.RegisterType<LoanDBContext>().As<DbContext>().InstancePerRequest();

            // Register Business Layer.
            builder.RegisterType<UnderwriterLoanManager>().As<IUnderwriterLoanManager>().InstancePerRequest();
            builder.RegisterType<BrokerLoanManager>().As<IBrokerLoanManager>().InstancePerRequest();
            builder.RegisterType<LoginManager>().As<ILoginManager>().InstancePerRequest();

            // Register Automapper Configuration
            builder.RegisterInstance(AutomapperConfiguration.Configure());
        }
    }
}