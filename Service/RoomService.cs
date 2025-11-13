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

        public void AddRoom(Room room)
        {
            var rooms = iRoom.getAllRoom();
            if (rooms.Any(r => r.HostelId == room.HostelId && r.RoomNumber == room.RoomNumber))
            {
                throw new InvalidOperationException("Room number already exists.");
            }
            if (room.Occupied > room.Capacity)
            {
                throw new InvalidOperationException("Occupied cannot be greater than Capacity.");
            }
            else
            {
                iRoom.AddRoom(room);
            }
        }

        public void EditRoomById(Room room)
        {
            var rooms = iRoom.getAllRoom();
            if (rooms.Any(r => r.HostelId == room.HostelId && r.RoomNumber == room.RoomNumber && r.RoomId != room.RoomId))
            {
                throw new InvalidOperationException("Room number already exists.");
            }
            if (room.Occupied > room.Capacity)
            {
                throw new InvalidOperationException("Occupied cannot be greater than Capacity.");
            }
            else
            {
                iRoom.EditRoomById(room);
            }
        }


        public List<Room> getAllRoom()
        {
            return iRoom.getAllRoom();
        }

        public Hostel GetHostelByWardenId(int wardenId)
        {
            return iRoom.GetHostelByWardenId(wardenId);
        }

        public Room GetRoomById(int id)
        {
            return iRoom.GetRoomById(id);
        }

        public List<Room> GetRoomsByWardenId(int wardenId)
        {
            return iRoom.GetRoomsByWardenId(wardenId);
        }

        public void ToggleStatus(int id)
        {
            iRoom.ToggleStatus(id);
        }
    }
}
