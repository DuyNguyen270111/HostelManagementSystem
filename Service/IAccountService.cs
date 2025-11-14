using HostelManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IAccountService
    {
        HostelUser GetAccountByEmailAndPassword(string userName, string password);
    }
}
