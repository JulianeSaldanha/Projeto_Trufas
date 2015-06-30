using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trufaria.Domain;
using Moq;
using Trufaria.Infra;
using Trufaria.Application;

namespace Trufaria.Test
{
    [TestClass]
    public class TrufaServiceTest
    {
        [TestMethod]
        public void CreateTrufaServiceValidationAndPersistenceTest()
        {
            //Arrange
            Trufa trufa = ObjectMother.GetTrufa();
            //Fake do repositório
            var repositoryFake = new Mock<ITrufaRepository>();
            repositoryFake.Setup(r => r.Save(trufa)).Returns(trufa);
            //Fake do dominio
            var trufaFake = new Mock<Trufa>();
            trufaFake.As<IObjectValidation>().Setup(b => b.Validate());

            ITrufaService service = new TrufaService(repositoryFake.Object);

            //Action
            service.Create(trufaFake.Object);

            //Assert
            trufaFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(trufaFake.Object));
        }

        [TestMethod]
        public void RetrieveTrufaServiceTest()
        {
            //Arrange
            Trufa trufa = ObjectMother.GetTrufa();
            //Fake do repositório
            var repositoryFake = new Mock<ITrufaRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(trufa);

            ITrufaService service = new TrufaService(repositoryFake.Object);

            //Action
            var trufaFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(trufaFake);
        }

        [TestMethod]
        public void UpdateTrufaServiceValidationAndPersistenceTest()
        {
            //Arrange
            Trufa trufa = ObjectMother.GetTrufa();
            //Fake do repositório
            var repositoryFake = new Mock<ITrufaRepository>();
            repositoryFake.Setup(r => r.Update(trufa)).Returns(trufa);
            //Fake do dominio
            var trufaFake = new Mock<Trufa>();
            trufaFake.As<IObjectValidation>().Setup(b => b.Validate());

            ITrufaService service = new TrufaService(repositoryFake.Object);

            //Action
            service.Update(trufaFake.Object);

            //Assert
            trufaFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(trufaFake.Object));
        }

        [TestMethod]
        public void DeleteTrufaServiceTest()
        {
            //Arrange
            Trufa trufa = null;
            //Fake do repositório
            var repositoryFake = new Mock<ITrufaRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(trufa);

            ITrufaService service = new TrufaService(repositoryFake.Object);

            //Action
            var trufaFake = service.Delete(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(trufaFake);
        }
    }


}

