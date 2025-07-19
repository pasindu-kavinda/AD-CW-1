using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories.Interface
{
    interface IDriverRepository
    {
        List<DriverModel> GetAllDrivers();
        DriverModel GetDriverById(int id);
        bool AddDriver(DriverModel driver);
        bool UpdateDriver(DriverModel driver);
        bool DeleteDriver(int id);
    }
}
