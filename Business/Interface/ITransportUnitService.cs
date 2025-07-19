using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Interface
{
    interface ITransportUnitService
    {
        List<TransportUnitModel> GetAllTransportUnits();
        TransportUnitModel GetTransportUnitById(int id);
        bool AddTransportUnit(TransportUnitModel transportUnit);
        bool UpdateTransportUnit(TransportUnitModel transportUnit);
        bool DeleteTransportUnit(int id);
    }
}
