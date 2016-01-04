using MWS.SharedKernel.Helpers;
using MWS.Domain.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWS.Domain.Entidades
{
    public class User
    {
        protected User() { }

        public User(string email, string password, bool isAdmin)
        {
            this.Email = email;
            this.Password = StringHelper.Encrypt(password);
            this.IsAdmin = isAdmin;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public void Authenticate(string email, string password)
        {
            this.AuthenticateUserScopeIsValid(email, password);

            //if (!this.AuthenticateUserScopeIsValid(email, password))
            //    return;
        }

        public void Register()
        {
            this.RegisterUserScopeIsValid();

            //if (!this.RegisterUserScopeIsValid())
            //    return;
        }

        public void GrantAdmin()
        {
            this.IsAdmin = true;
        }

        public void RevokeAdmin()
        {
            this.IsAdmin = false;
        }
    }
}
