using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Interface
{
    interface IJobService
    {
        List<JobModel> GetAllJobs();
        JobModel GetJobById(int id);
        List<JobModel> GetJobsByCustomerId(int customerId);
        int AddJob(JobModel job);
        bool UpdateJob(JobModel job);
        bool DeleteJob(int id);
    }
}
