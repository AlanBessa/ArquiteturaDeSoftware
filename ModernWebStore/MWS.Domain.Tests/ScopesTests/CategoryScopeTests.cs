using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Domain.Entidades;
using MWS.Domain.Scopes;

namespace MWS.Domain.Tests.ScopesTests
{
    [TestClass]    
    public class CategoryScopeTests
    {
        [TestMethod]
        [TestCategory("Category")]
        public void ShouldRegisterCategory()
        {
            var category = new Category("Placa Mãe");
            Assert.AreEqual(true, CategoryScopes.CreateCategoryScopeIsValid(category));
        }

        [TestMethod]
        [TestCategory("Category")]
        public void ShouldUpdateCategoryTitle()
        {
            var category = new Category("Placa Mãe");
            Assert.AreEqual(true, CategoryScopes.EditCategoryScopeIsValid(category, "MotherBoards"));
        }
    }
}
