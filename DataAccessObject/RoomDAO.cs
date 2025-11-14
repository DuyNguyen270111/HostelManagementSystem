using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.BusinessObject;


namespace DataAccessObject
{
    public class RoomDAO
    {
        public static List<Room> getAllRoom()
        {
            using (var _context = new ProjectttContext())
            {
                return _context.Rooms.ToList();
            }
        }
    }
}
