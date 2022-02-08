using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LoanApplication
{
    public class LoginDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public bool IsUserValid { get; set; }
    }
}
