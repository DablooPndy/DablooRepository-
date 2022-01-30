using System.Web;
using System.Web.Mvc;
using API.LoanApplication.ExceptionHandling;

namespace API.LoanApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Register All filetrs here
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new CustomExceptionFilter());
        }
    }
}
