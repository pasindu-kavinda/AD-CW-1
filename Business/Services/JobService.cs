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
    class JobService : IJobService
    {
        private readonly IJobRepository _repo;
        private readonly JobValidator _validator;

        public JobService(IJobRepository repo)
        {
            _repo = repo;
            _validator = new JobValidator();
        }

        public int AddJob(JobModel job)
        {
            var validationResult = _validator.Validate(job);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.AddJob(job);
        }

        public bool UpdateJob(JobModel job)
        {
            var validationResult = _validator.Validate(job);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.UpdateJob(job);
        }

        public bool DeleteJob(int id)
        {
            return _repo.DeleteJob(id);
        }

        public List<JobModel> GetAllJobs()
        {
            return _repo.GetAllJobs();
        }

        public JobModel GetJobById(int id)
        {
            return _repo.GetJobById(id);
        }

        public List<JobModel> GetJobsByCustomerId(int customerId)
        {
            return _repo.GetJobsByCustomerId(customerId);
        }
    }
}
