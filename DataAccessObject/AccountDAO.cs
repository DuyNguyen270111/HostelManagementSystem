using HostelManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class AccountDAO 
    {
        public static HostelUser GetAccountByEmailAndPassword(string userName, string password)
        {
            using (var _context = new ProjectttContext())
            {
                return _context.HostelUsers.FirstOrDefault(a => a.Username == userName && a.Password == password);
            }
        }
    }
}
