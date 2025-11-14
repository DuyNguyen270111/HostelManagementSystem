using DataAccessObject;
using HostelManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepo : IAccountRepo
    {
        public HostelUser GetAccountByEmailAndPassword(string userName, string password)
        {
            return AccountDAO.GetAccountByEmailAndPassword(userName, password);
        }

        public List<HostelUser> getAllHostelU()
        {
            return AccountDAO.getAllHostelU();
        }
    }
}
