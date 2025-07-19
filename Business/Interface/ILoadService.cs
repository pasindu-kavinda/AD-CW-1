using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Interface
{
    interface ILoadService
    {
        List<LoadModel> GetAllLoads();
        LoadModel GetLoadById(int id);
        List<LoadModel> GetLoadsByJobId(int jobId);
        LoadModel GetLoadByLoadNumber(string loadNumber);
        bool AddLoad(LoadModel load);
        bool UpdateLoad(LoadModel load);
        bool DeleteLoad(int id);
        bool DeleteLoadsByJobId(int jobId);
    }
}
