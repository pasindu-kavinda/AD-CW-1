using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories.Interface
{
    interface ITruckRepository
    {
        List<TruckModel> GetAllTrucks();
        TruckModel GetTruckById(int id);
        bool AddTruck(TruckModel Truck);
        bool UpdateTruck(TruckModel Truck);
        bool DeleteTruck(int id);
    }
}
