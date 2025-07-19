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
    class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly ProductValidator _validator;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
            _validator = new ProductValidator();
        }

        public bool AddProduct(ProductModel product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.AddProduct(product);
        }

        public bool UpdateProduct(ProductModel product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            return _repo.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _repo.DeleteProduct(id);
        }

        public List<ProductModel> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public ProductModel GetProductById(int id)
        {
            return _repo.GetProductById(id);
        }
    }
}
