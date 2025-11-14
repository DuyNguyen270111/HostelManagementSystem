using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.BusinessObject;

namespace Service
{
    public interface IRoomService
    {
        List<Room> getAllRoom();
        void AddRoom(Room room);
        Room GetRoomById(int id);
        void EditRoomById(Room room);
        void ToggleStatus(int id);
        List<Room> GetRoomsByWardenId(int wardenId);
        Hostel GetHostelByWardenId(int wardenId);
        int GetRoomCountByHostelId(int hostelId);
    }
}
