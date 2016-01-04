using MWS.Domain.Entidades;
using MWS.SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MWS.Domain.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> AuthenticateUser(string email, string password)
        {
            string encriptedPassword = StringHelper.Encrypt(password);
            return x => x.Email == email && x.Password == encriptedPassword;
        }

        public static Expression<Func<User, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }
    }
}
