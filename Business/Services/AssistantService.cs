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
    class AssistantService : IAssistantService
    {
        private readonly IAssistantRepository _repo;
        private readonly AssistantValidator _validator;

        public AssistantService(IAssistantRepository repo)
        {
            _repo = repo;
            _validator = new AssistantValidator();
        }

        public bool AddAssistant(AssistantModel assistant)
        {
            var validationResult = _validator.Validate(assistant);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.AddAssistant(assistant);
        }

        public bool UpdateAssistant(AssistantModel assistant)
        {
            var validationResult = _validator.Validate(assistant);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.UpdateAssistant(assistant);
        }

        public bool DeleteAssistant(int id)
        {
            return _repo.DeleteAssistant(id);
        }

        public List<AssistantModel> GetAllAssistants()
        {
            return _repo.GetAllAssistants();
        }

        public AssistantModel GetAssistantById(int id)
        {
            return _repo.GetAssistantById(id);
        }
    }
}
