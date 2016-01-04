using MWS.Domain.Commands.CategoryCommands;
using MWS.Domain.Entidades;
using System.Collections.Generic;

namespace MWS.Domain.Services
{
    public interface ICategoryApplicationService
    {
        List<Category> Get();

        List<Category> Get(int skip, int take);

        Category Get(int id);

        Category Create(CreateCategoryCommand command);

        Category Update(EditCategoryCommand command);

        Category Delete(int id);
    }
}