using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trufaria.Domain;
using Trufaria.Infra;

namespace Trufaria.Test
{
    [TestClass]

    public class SaborDomainTest
    {
        [TestMethod]
        public void CreateASaborTest()
        {
            Sabor sabor = ObjectMother.GetSabor();

            Assert.IsNotNull(sabor);
        }

        [TestMethod]
        public void CreateAValidSaborTest()
        {
            Sabor sabor = ObjectMother.GetSabor();

            Validator.Validate(sabor);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidSaborNameTest()
        {
            Sabor sabor = new Sabor();

            Validator.Validate(sabor);
        }


    }




}
