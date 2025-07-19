using AD_CW_1.Business.Interface;
using AD_CW_1.Models;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Services
{
    class LoadService : ILoadService
    {
        private readonly ILoadRepository _repo;
        private readonly LoadValidator _validator;

        public LoadService(ILoadRepository repo)
        {
            _repo = repo;
            _validator = new LoadValidator();
        }

        public bool AddLoad(LoadModel load)
        {
            var validationResult = _validator.Validate(load);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.AddLoad(load);
        }

        public bool UpdateLoad(LoadModel load)
        {
            var validationResult = _validator.Validate(load);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.UpdateLoad(load);
        }

        public bool DeleteLoad(int id)
        {
            return _repo.DeleteLoad(id);
        }

        public bool DeleteLoadsByJobId(int jobId)
        {
            return _repo.DeleteLoadsByJobId(jobId);
        }

        public List<LoadModel> GetAllLoads()
        {
            return _repo.GetAllLoads();
        }

        public LoadModel GetLoadById(int id)
        {
            return _repo.GetLoadById(id);
        }

        public List<LoadModel> GetLoadsByJobId(int jobId)
        {
            return _repo.GetLoadsByJobId(jobId);
        }

        public LoadModel GetLoadByLoadNumber(string loadNumber)
        {
            return _repo.GetLoadByLoadNumber(loadNumber);
        }
    }
}
