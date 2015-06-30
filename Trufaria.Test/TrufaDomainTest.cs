using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trufaria.Domain;
using Trufaria.Infra;

namespace Trufaria.Test
{
    [TestClass]
    public class TrufaDomainTest
    {
        [TestMethod]
        public void CreateATrufaTest()
        {
            Trufa trufa = ObjectMother.GetTrufa();

            Assert.IsNotNull(trufa);
        }

        [TestMethod]
        public void CreateAValidTrufaTest()
        {
            Trufa trufa = ObjectMother.GetTrufa();

            Validator.Validate(trufa);
        }


         [TestMethod]
         [ExpectedException(typeof(Exception))]
         public void CreateAInvalidTrufaDataValidadeTest()
         {
             Trufa trufa = new Trufa();
             trufa.DataValidade = new DateTime(2015, 06, 15, 0, 0, 0);

             Validator.Validate(trufa);
         } 

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidTrufaValorTest()
        {
            Trufa trufa = new Trufa();
            trufa.Valor = 3.00;

            Validator.Validate(trufa);
        }
    }

}
