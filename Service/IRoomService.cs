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
    }
}
