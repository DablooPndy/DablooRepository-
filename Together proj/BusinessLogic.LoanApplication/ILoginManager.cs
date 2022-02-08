using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.LoanApplication;

namespace BusinessLogic.LoanApplication
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoginManager
    {
        LoginDetails ValidateUser(LoginDetails _loginDetails);
    }
}
