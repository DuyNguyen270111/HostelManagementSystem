using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.BusinessObject;

using Microsoft.EntityFrameworkCore;


namespace DataAccessObject
{
    public class RoomDAO
    {
        public static List<Room> getAllRoom()
        {
            using (var _context = new ProjectttContext())
            {
                return _context.Rooms.Include(x => x.Hostel).ToList();
            }
        }
        public static Hostel GetHostelByWardenId(int wardenId)
        {
            using (var _context = new ProjectttContext())
            {

                var hostel = _context.Wardens
                     .Where(w => w.WardenId == wardenId)
                     .Select(w => w.Hostel)
                     .FirstOrDefault();

                return hostel;
            }
        }
        public static List<Room> GetRoomsByWardenId(int wardenId)
        {
            using (var _context = new ProjectttContext())
            {
                var hostelId = _context.Wardens
                    .Where(w => w.WardenId == wardenId)
                    .Select(w => w.HostelId)
                    .FirstOrDefault();
                if(hostelId == 0)
                {
                    return new List<Room>();
                }
                return _context.Rooms
                    .Include(r => r.Hostel)
                    .Where(r => r.HostelId == hostelId)
                    .ToList();
            }
        }
        public static void AddRoom(Room room)
        {
            using (var _context = new ProjectttContext())
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
            }
        }
        
        public static Room GetRoomById(int id)
        {
            using (var _context = new ProjectttContext())
            {
                return _context.Rooms.FirstOrDefault(r => r.RoomId == id);
            }
        }
        
        public static void EditRoomById(Room room)
        {

            using (var _context = new ProjectttContext())
            {
                var existing = _context.Rooms.FirstOrDefault(x => x.RoomId == room.RoomId);
                if (existing != null)
                {
                    _context.Entry(existing).CurrentValues.SetValues(room);
                    _context.SaveChanges();
                }
            }

        }
        public static void ToggleStatus(int id)
        {
            using (var _context = new ProjectttContext())
            {
                var room = _context.Rooms.FirstOrDefault(r => r.RoomId == id);
                if (room == null)
                {
                    throw new InvalidOperationException("Room not found.");
                }
                if (room.Status == "Active")
                {
                    room.Status = "InActive";
                    EditRoomById(room);
                }
                else
                {
                    room.Status = "Active";
                    EditRoomById(room);
                }
            }
        }
        public static int GetRoomCountByHostelId(int hostelId)
        {
            using (var context = new ProjectttContext())
            {
                // Đếm số phòng thuộc hostel có HostelId tương ứng
                int count = context.Rooms.Count(r => r.HostelId == hostelId);
                return count;
            }
        }
    }
}
