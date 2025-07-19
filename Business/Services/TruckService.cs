using AD_CW_1.Business.Interface;
using AD_CW_1.Models;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD_CW_1.Business.Services
{
    class TruckService : ITruckService
    {
        private readonly ITruckRepository _repo;
        private readonly TruckValidator _validator;

        public TruckService(ITruckRepository repo)
        {
            _repo = repo;
            _validator = new TruckValidator();
        }

        public bool AddTruck(TruckModel truck)
        {
            var validationResult = _validator.Validate(truck);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.AddTruck(truck);
        }

        public bool UpdateTruck(TruckModel truck)
        {
            var validationResult = _validator.Validate(truck);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.UpdateTruck(truck);
        }

        public bool DeleteTruck(int id)
        {
            return _repo.DeleteTruck(id);
        }

        public List<TruckModel> GetAllTrucks()
        {
            return _repo.GetAllTrucks();
        }

        public TruckModel GetTruckById(int id)
        {
            return _repo.GetTruckById(id);
        }
    }
}
