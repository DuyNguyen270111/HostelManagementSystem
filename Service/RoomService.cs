using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.BusinessObject;
using Repository;

namespace Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo iRoom;
        public RoomService()
        {
            iRoom = new RoomRepo();
        } 
        public List<Room> getAllRoom()
        {
            return iRoom.getAllRoom();
        }
    }
}
