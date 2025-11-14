using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.BusinessObject;
using Repository;

namespace Service
{
    public class HostelService : IHostelService
    {
        private readonly IHostelRepo iHostel;
        private readonly IRoomRepo iRoom;
        public HostelService()
        {
            iHostel = new HostelRepo();
            iRoom = new RoomRepo();
        }

        public void AddHostel(Hostel hostel)
        {
            var hostelList = iHostel.GetAllHostel();
            if (hostelList.Any( r => r.Name == hostel.Name))
            {
                throw new InvalidOperationException("Hostel name already exists.");
            }
            else
            {
                iHostel.AddHostel(hostel);
            }
            
        }

        public void EditHostelById(Hostel hostel)
        {
            var hostelList = iHostel.GetAllHostel();
            int countRoom = iRoom.GetRoomCountByHostelId(hostel.HostelId);
            if (hostelList.Any(r => r.Name == hostel.Name && r.HostelId != hostel.HostelId))
            {
                throw new InvalidOperationException("Hostel name already exists.");
            }
            if (hostel.TotalRooms < countRoom)
            {
                throw new InvalidOperationException("The total number of rooms cannot be less than the number of available rooms.");
            }
            iHostel.EditHostelById(hostel);
        }

        public List<Hostel> GetAllHostel()
        {
            return iHostel.GetAllHostel();
        }

        public Hostel GetHostelById(int hostelId)
        {
            return iHostel.GetHostelById(hostelId);
        }

        public string GetHostelNameById(int hostelId)
        {
            return iHostel.GetHostelNameById(hostelId);
        }

        public int GetTotalRoomByHostelID(int hostelId)
        {
            return iHostel.GetTotalRoomByHostelID(hostelId);
        }

        public void ToggleStatus(int id)
        {
            iHostel.ToggleStatus(id);
        }
    }
}
