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
    class TransportUnitService : ITransportUnitService
    {
        private readonly ITransportUnitRepository _repo;
        private readonly TransportUnitValidator _validator;

        public TransportUnitService(ITransportUnitRepository repo)
        {
            _repo = repo;
            _validator = new TransportUnitValidator();
        }

        public bool AddTransportUnit(TransportUnitModel transportUnit)
        {
            var validationResult = _validator.Validate(transportUnit);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.AddTransportUnit(transportUnit);
        }

        public bool UpdateTransportUnit(TransportUnitModel transportUnit)
        {
            var validationResult = _validator.Validate(transportUnit);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.UpdateTransportUnit(transportUnit);
        }

        public bool DeleteTransportUnit(int id)
        {
            return _repo.DeleteTransportUnit(id);
        }

        public List<TransportUnitModel> GetAllTransportUnits()
        {
            return _repo.GetAllTransportUnits();
        }

        public TransportUnitModel GetTransportUnitById(int id)
        {
            return _repo.GetTransportUnitById(id);
        }
    }
}
