using MWS.Domain.Commands.UserCommands;
using MWS.Domain.Entidades;
using MWS.Domain.Repositories;
using MWS.Domain.Services;
using MWS.Infra.Persistence;
using System;
using System.Collections.Generic;

namespace MWS.ApplicationService
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Email, command.Password, command.IsAdmin);
            user.Register();

            _repository.Register(user);

            if (Commit())
                return user;

            return null;
        }

        public User Authenticate(string email, string password)
        {
            return _repository.Authenticate(email, password);
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }
    }
}