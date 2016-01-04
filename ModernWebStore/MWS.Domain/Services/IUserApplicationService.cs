using MWS.Domain.Commands.UserCommands;
using MWS.Domain.Entidades;
using System.Collections.Generic;

namespace MWS.Domain.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);

        User Authenticate(string email, string password);

        List<User> List();
    }
}