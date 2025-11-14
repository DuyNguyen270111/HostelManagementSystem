using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using HostelManagement.BusinessObject;

namespace Repository
{
    public class HostelRepo : IHostelRepo
    {
        public void AddHostel(Hostel hostel)
        {
            HostelDAO.AddHostel(hostel);
        }

        public void EditHostelById(Hostel hostel)
        {
            HostelDAO.EditHostelById(hostel);
        }

        public List<Hostel> GetAllHostel()
        {
            return HostelDAO.GetAllHostel();
        }

        public Hostel GetHostelById(int hostelId)
        {
            return HostelDAO.GetHostelById(hostelId);
        }

        public string GetHostelNameById(int hostelId)
        {
            return HostelDAO.GetHostelNameById(hostelId);
        }

        public int GetTotalRoomByHostelID(int hostelId)
        {
            return HostelDAO.GetTotalRoomByHostelID(hostelId);
        }

        public void ToggleStatus(int id)
        {
            HostelDAO.ToggleStatus(id);
        }
    }
}
