using MWS.Domain.Commands.ProductCommands;
using MWS.Domain.Entidades;
using System.Collections.Generic;

namespace MWS.Domain.Services
{
    public interface IProductApplicationService
    {
        List<Product> Get();

        List<Product> Get(int skip, int take);

        List<Product> GetOutOfStock();

        Product Get(int id);

        Product Create(CreateProductCommand command);

        Product UpdateBasicInformation(UpdateProductInfoCommand command);

        Product Delete(int id);
    }
}