using MWS.Domain.Entidades;
using MWS.Domain.Repositories;
using MWS.Domain.Specs;
using MWS.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace MWS.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private StoreDataContext _context;

        public UserRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
        }

        public User Authenticate(string email, string password)
        {
            return _context.Users
                .Where(UserSpecs.AuthenticateUser(email, password))
                .FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _context.Users
                .Where(UserSpecs.GetByEmail(email))
                .FirstOrDefault();
        }

        public List<User> List()
        {
            return _context.Users.OrderBy(x => x.Email).ToList();
        }
    }
}