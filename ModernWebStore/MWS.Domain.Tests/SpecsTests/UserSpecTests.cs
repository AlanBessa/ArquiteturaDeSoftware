using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Domain.Entidades;
using System.Collections.Generic;
using MWS.SharedKernel.Helpers;
using MWS.Domain.Specs;

namespace MWS.Domain.Tests.SpecsTests
{
    [TestClass]
    public class UserSpecTests
    {
        private List<User> _users;

        public UserSpecTests()
        {
            _users = new List<User>();
            _users.Add(new User("andrebaltieri@hotmail.com", StringHelper.Encrypt("123456"), true));
        }

        [TestMethod]
        [TestCategory("User Specs - Authenticate")]
        public void ShouldAuthenticate()
        {
            var exp = UserSpecs.AuthenticateUser("andrebaltieri@hotmail.com", "123456");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User Specs - Authenticate")]
        public void ShouldNotAuthenticateWhenEmailIsWrong()
        {
            var exp = UserSpecs.AuthenticateUser("andrebaltieri@gmail.com", "123456");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User Specs - Authenticate")]
        public void ShouldNotAuthenticateWhenPasswordIsWrong()
        {
            var exp = UserSpecs.AuthenticateUser("andrebaltieri@gmail.com", "1233456");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }
    }
}
