using AD_CW_1.Business.Interface;
using AD_CW_1.Models;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Services
{
    class JobProductService : IJobProductService
    {
        private readonly IJobProductRepository _repo;
        private readonly JobProductValidator _validator;

        public JobProductService(IJobProductRepository repo)
        {
            _repo = repo;
            _validator = new JobProductValidator();
        }

        public int AddJobProduct(JobProductModel jobProduct)
        {
            Console.WriteLine("Adding JobProduct: " + jobProduct.ProductName);
            var validationResult = _validator.Validate(jobProduct);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.AddJobProduct(jobProduct);
        }

        public bool UpdateJobProduct(JobProductModel jobProduct)
        {
            var validationResult = _validator.Validate(jobProduct);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.UpdateJobProduct(jobProduct);
        }

        public bool DeleteJobProduct(int id)
        {
            return _repo.DeleteJobProduct(id);
        }

        public bool DeleteJobProductsByJobId(int jobId)
        {
            return _repo.DeleteJobProductsByJobId(jobId);
        }

        public List<JobProductModel> GetAllJobProducts()
        {
            return _repo.GetAllJobProducts();
        }

        public JobProductModel GetJobProductById(int id)
        {
            return _repo.GetJobProductById(id);
        }

        public List<JobProductModel> GetJobProductsByJobId(int jobId)
        {
            return _repo.GetJobProductsByJobId(jobId);
        }

        public List<JobProductModel> GetJobProductsByProductId(int productId)
        {
            return _repo.GetJobProductsByProductId(productId);
        }
    }
}
