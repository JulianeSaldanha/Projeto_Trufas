using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trufaria.Infra.Data;
using System.Data.Entity;
using System.Linq;
using Trufaria.Domain;

namespace Trufaria.Test
{
    [TestClass]
    public class SaborRepositoryTest
    {
        private TrufaContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            //Database.SetInitializer(new DropCreateDatabaseAlways<TrufaContext>());
            using (TrufaContext context = new TrufaContext())
            {
                context.Database.Delete();
                context.Database.CreateIfNotExists();
            }
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new TrufaContext();
            _contextForTest.Sabores.AddRange(ObjectMother.GetSabores());
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateSaborRepositoryTest()
        {
            //Arrange
            Sabor s = ObjectMother.GetSabor();
            ISaborRepository repository = new SaborRepository();

            //Action
            Sabor newSabor = repository.Save(s);

            //Assert
            Assert.IsTrue(newSabor.Id > 0);
        }

        [TestMethod]
        public void RetrieveSaborRepositoryTest()
        {
            //Arrange
            ISaborRepository repository = new SaborRepository();

            //Action
            Sabor sabor = repository.Get(1);

            //Assert
            Assert.IsNotNull(sabor);
            Assert.IsTrue(sabor.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(sabor.NameSabor));
            
            }

        [TestMethod]
        public void UpdateSaborRepositoryTest()
        {
            //Arrange
            ISaborRepository repository = new SaborRepository();
            //Trufa trufa = _contextForTest.Trufas.Find(1);
            //trufa.DataFabricacao = new DateTime(2015, 06, 01);
            //trufa.DataValidade = new DateTime(2015, 06, 11);
            //trufa.Quantidade = 5;
            //trufa.Tamanho = "Grande";
            //trufa.Valor = 3.00;

            Sabor sabor = _contextForTest.Sabores.Find(1);
            sabor.NameSabor = "Brigadeiro";
            //sabor.Trufa = trufa;

            //Action
            var updatedSabor = repository.Update(sabor);

            //Assert
            var persistedSabor = _contextForTest.Sabores.Find(1);
            Assert.IsNotNull(updatedSabor);
            Assert.AreEqual(updatedSabor.Id, persistedSabor.Id);
            Assert.AreEqual(updatedSabor.NameSabor, persistedSabor.NameSabor);
            //Assert.AreEqual(updatedSabor.Trufa, persistedSabor.Trufa);

        }

        [TestMethod]
        public void DeleteSaborRepositoryTest()
        {
            //Arrange
            ISaborRepository repository = new SaborRepository();

            //Action
            var deletedSabor = repository.Delete(1);

            //Assert
            var persistedSabor = _contextForTest.Sabores.FirstOrDefault(x => x.Id == 1);
            Assert.IsNull(persistedSabor);

            
        }

    }
}

