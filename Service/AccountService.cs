using HostelManagement.BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo iac;
        public AccountService()
        {
            iac = new AccountRepo();
        }
        public HostelUser GetAccountByEmailAndPassword(string userName, string password)
        {
            return iac.GetAccountByEmailAndPassword(userName, password);
        }
    }
}
