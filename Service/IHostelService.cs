using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.BusinessObject;

namespace Service
{
    public interface IHostelService
    {
        List<Hostel> GetAllHostel();
        int GetTotalRoomByHostelID(int hostelId);
        string GetHostelNameById(int hostelId);
        void AddHostel(Hostel hostel);
        void ToggleStatus(int id);
        Hostel GetHostelById(int hostelId);
        void EditHostelById(Hostel hostel);
    }
}
