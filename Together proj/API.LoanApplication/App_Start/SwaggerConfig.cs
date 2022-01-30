using System.Web.Http;
using WebActivatorEx;
using API.LoanApplication;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace API.LoanApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                                {
                                    c.SingleApiVersion("v1", "API.LoanApplication");
                                })
                .EnableSwaggerUi(c =>
                                {

                                });
        }
    }
}
