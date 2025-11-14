using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.BusinessObject;


namespace DataAccessObject
{
    public class HostelDAO
    {
        public static List<Hostel> GetAllHostel()
        {
            using (var _context = new ProjectttContext())
            {
                return _context.Hostels.ToList();
            }
        }
        public static void AddHostel(Hostel hostel)
        {
            using (var _context = new ProjectttContext())
            {
                _context.Hostels.Add(hostel);
                _context.SaveChanges();
            }
        }
        public static int GetTotalRoomByHostelID(int hostelId)
        {
            using (var _context = new ProjectttContext())
            {
                var totalRooms = _context.Hostels
                    .Where(r => r.HostelId == hostelId)
                    .Select(r => r.TotalRooms)
                    .FirstOrDefault();
                return totalRooms ?? 0;
            }
        }
        public static Hostel GetHostelById(int hostelId)
        {
            using (var _context = new ProjectttContext())
            {
                return _context.Hostels.FirstOrDefault(h => h.HostelId == hostelId);
            }
        }
        public static string GetHostelNameById(int hostelId)
        {
            using (var _context = new ProjectttContext())
            {
                var hostelName = _context.Hostels
                    .Where(h => h.HostelId == hostelId)
                    .Select(h => h.Name)
                    .FirstOrDefault();
                return hostelName ?? string.Empty;
            }
        }
        public static void EditHostelById(Hostel hostel)
        {

            using (var _context = new ProjectttContext())
            {
                var existing = _context.Hostels.FirstOrDefault(x => x.HostelId == hostel.HostelId);
                if (existing != null)
                {
                    _context.Entry(existing).CurrentValues.SetValues(hostel);
                    _context.SaveChanges();
                }
            }

        }
        public static void ToggleStatus(int id)
        {
            using (var _context = new ProjectttContext())
            {
                var hostel = _context.Hostels.FirstOrDefault(r => r.HostelId == id);
                if (hostel == null)
                {
                    throw new InvalidOperationException("Room not found.");
                }
                if (hostel.Status == "Active")
                {
                    hostel.Status = "InActive";
                    EditHostelById(hostel);
                }
                else
                {
                    hostel.Status = "Active";
                    EditHostelById(hostel);
                }
            }
        }
    }
}
