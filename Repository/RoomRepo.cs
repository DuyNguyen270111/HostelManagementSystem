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
        public void AddRoom(Room room)
        {
            RoomDAO.AddRoom(room);
        }

        public void EditRoomById(Room room)
        {
            RoomDAO.EditRoomById(room);
        }

        

        public List<Room> getAllRoom()
        {
            return RoomDAO.getAllRoom();
        }

        public Hostel GetHostelByWardenId(int wardenId)
        {
            return RoomDAO.GetHostelByWardenId(wardenId);
        }

        public Room GetRoomById(int id)
        {
            return RoomDAO.GetRoomById(id);
        }

        public int GetRoomCountByHostelId(int hostelId)
        {
            return RoomDAO.GetRoomCountByHostelId(hostelId);
        }

        public List<Room> GetRoomsByWardenId(int wardenId)
        {
            return RoomDAO.GetRoomsByWardenId(wardenId);
        }

        public void ToggleStatus(int id)
        {
            RoomDAO.ToggleStatus(id);
        }
    }
}
