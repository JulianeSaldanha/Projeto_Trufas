using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trufaria.Domain;
using Moq;
using Trufaria.Infra;
using Trufaria.Application;

namespace Trufaria.Test
{
    [TestClass]
    public class SaborServiceTest
    {
        [TestMethod]
        public void CreateSaborServiceValidationAndPersistenceTest()
        {
            //Arrange
            Sabor sabor = ObjectMother.GetSabor();
            //Fake do repositório
            var repositoryFake = new Mock<ISaborRepository>();
            repositoryFake.Setup(r => r.Save(sabor)).Returns(sabor);
            //Fake do dominio
            var saborFake = new Mock<Sabor>();
            saborFake.As<IObjectValidation>().Setup(b => b.Validate());

            ISaborService service = new SaborService(repositoryFake.Object);

            //Action
            service.Create(saborFake.Object);

            //Assert
            saborFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(saborFake.Object));
        }

        [TestMethod]
        public void RetrieveSaborServiceTest()
        {
            //Arrange
            Sabor sabor = ObjectMother.GetSabor();
            //Fake do repositório
            var repositoryFake = new Mock<ISaborRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(sabor);

            ISaborService service = new SaborService(repositoryFake.Object);

            //Action
            var saborFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(saborFake);
        }

        [TestMethod]
        public void UpdateSaborServiceValidationAndPersistenceTest()
        {
            //Arrange
            Sabor sabor = ObjectMother.GetSabor();
            //Fake do repositório
            var repositoryFake = new Mock<ISaborRepository>();
            repositoryFake.Setup(r => r.Update(sabor)).Returns(sabor);
            //Fake do dominio
            var saborFake = new Mock<Sabor>();
            saborFake.As<IObjectValidation>().Setup(b => b.Validate());

            ISaborService service = new SaborService(repositoryFake.Object);

            //Action
            service.Update(saborFake.Object);

            //Assert
            saborFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(saborFake.Object));
        }

        [TestMethod]
        public void DeleteSaborServiceTest()
        {
            //Arrange
            Sabor sabor = null;
            //Fake do repositório
            var repositoryFake = new Mock<ISaborRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(sabor);

            ISaborService service = new SaborService(repositoryFake.Object);

            //Action
            var saborFake = service.Delete(1);

            //Asserts
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(saborFake);
        }
    }
}

