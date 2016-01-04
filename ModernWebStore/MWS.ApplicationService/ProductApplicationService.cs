using MWS.Domain.Commands.ProductCommands;
using MWS.Domain.Entidades;
using MWS.Domain.Repositories;
using MWS.Domain.Services;
using MWS.Infra.Persistence;
using System.Collections.Generic;

namespace MWS.ApplicationService
{
    public class ProductApplicationService : ApplicationService, IProductApplicationService
    {
        private IProductRepository _repository;

        public ProductApplicationService(IProductRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<Product> Get()
        {
            return _repository.GetProductsInStock();
        }

        public List<Product> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public List<Product> GetOutOfStock()
        {
            return _repository.GetProductsOutOfStock();
        }

        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        public Product Create(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Description, command.Price, command.QuantityOnHand, command.CategoryId, command.Image);
            product.Register();

            _repository.Create(product);

            if (Commit())
                return product;

            return null;
        }

        public Product UpdateBasicInformation(UpdateProductInfoCommand command)
        {
            var product = _repository.Get(command.Id);
            product.UpdateInfo(command.Title, command.Description, command.CategoryId);

            _repository.Update(product);

            if (Commit())
                return product;

            return null;
        }

        public Product Delete(int id)
        {
            var product = _repository.Get(id);
            _repository.Delete(product);

            if (Commit())
                return product;

            return null;
        }
    }
}