using HostelManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  public interface IAccountRepo
    {
        HostelUser GetAccountByEmailAndPassword(string userName, string password);
        List<HostelUser> getAllHostelU();
    }
}
