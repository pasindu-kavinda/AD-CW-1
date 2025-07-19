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
    class DriverService : IDriverService
    {
        private readonly IDriverRepository _repo;
        private readonly DriverValidator _validator;

        public DriverService(IDriverRepository repo)
        {
            _repo = repo;
            _validator = new DriverValidator();
        }

        public bool AddDriver(DriverModel driver)
        {
            var validationResult = _validator.Validate(driver);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.AddDriver(driver);
        }

        public bool UpdateDriver(DriverModel driver)
        {
            var validationResult = _validator.Validate(driver);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.UpdateDriver(driver);
        }

        public bool DeleteDriver(int id)
        {
            return _repo.DeleteDriver(id);
        }

        public List<DriverModel> GetAllDrivers()
        {
            return _repo.GetAllDrivers();
        }

        public DriverModel GetDriverById(int id)
        {
            return _repo.GetDriverById(id);
        }
    }
}
