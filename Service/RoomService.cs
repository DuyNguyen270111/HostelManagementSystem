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
        private readonly IHostelRepo iHostel;
        public RoomService()
        {
            iRoom = new RoomRepo();
            iHostel = new HostelRepo();
        }

        public void AddRoom(Room room)
        {
            var rooms = iRoom.getAllRoom();
            int countRoom = iRoom.GetRoomCountByHostelId(room.HostelId.Value);
            int maxRooms = iHostel.GetTotalRoomByHostelID(room.HostelId.Value);
            var hostelName = iHostel.GetHostelNameById(room.HostelId.Value);
            if (rooms.Any(r => r.HostelId == room.HostelId && r.RoomNumber == room.RoomNumber))
            {
                throw new InvalidOperationException("Room number already exists.");
            }
            if (room.Occupied > room.Capacity)
            {
                throw new InvalidOperationException("Occupied cannot be greater than Capacity.");
            }
            if (countRoom >= maxRooms)
            {
                throw new InvalidOperationException($"{hostelName} is full of room ! Cannot add to this Hostel any more room."  );
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

        public int GetRoomCountByHostelId(int hostelId)
        {
            return iRoom.GetRoomCountByHostelId(hostelId);
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
