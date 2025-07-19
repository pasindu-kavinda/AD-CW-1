using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Interface
{
    interface IJobProductService
    {
        List<JobProductModel> GetAllJobProducts();
        JobProductModel GetJobProductById(int id);
        List<JobProductModel> GetJobProductsByJobId(int jobId);
        List<JobProductModel> GetJobProductsByProductId(int productId);
        int AddJobProduct(JobProductModel jobProduct);
        bool UpdateJobProduct(JobProductModel jobProduct);
        bool DeleteJobProduct(int id);
        bool DeleteJobProductsByJobId(int jobId);
    }
}
