using MWS.Domain.Entidades;
using System.Collections.Generic;

namespace MWS.Domain.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);

        User Authenticate(string email, string password);

        User GetByEmail(string email);

        List<User> List();
    }
}