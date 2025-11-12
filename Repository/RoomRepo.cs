using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using HostelManagement.BusinessObject;

namespace Repository
{
    public class RoomRepo : IRoomRepo
    {
        public List<Room> getAllRoom()
        {
            return RoomDAO.getAllRoom();
        }
    }
}
