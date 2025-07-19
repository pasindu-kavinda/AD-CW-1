using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Interface
{
    interface ITruckService
    {
        List<TruckModel> GetAllTrucks();
        TruckModel GetTruckById(int id);
        bool AddTruck(TruckModel truck);
        bool UpdateTruck(TruckModel truck);
        bool DeleteTruck(int id);
    }
}
