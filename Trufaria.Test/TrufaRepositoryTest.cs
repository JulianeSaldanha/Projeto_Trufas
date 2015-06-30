using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trufaria.Infra.Data;
using System.Data.Entity;
using System.Linq;
using Trufaria.Domain;

namespace Trufaria.Test
{
    [TestClass]
    public class TrufaRepositoryTest
    {
        private TrufaContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            // Database.SetInitializer(new DropCreateDatabaseAlways<TrufaContext>());
            using (TrufaContext context = new TrufaContext())
            {
                context.Database.Delete();
                context.Database.CreateIfNotExists();
            }
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new TrufaContext();

            var trufa = ObjectMother.GetTrufa();

            var trufapequena = ObjectMother.GetTrufa();
            trufapequena.Tamanho = "Pequena";

            var trufamedia = ObjectMother.GetTrufa();
            trufamedia.Tamanho = "Media";

            var trufagrande = ObjectMother.GetTrufa();
            trufagrande.Tamanho = "Grande";


            _contextForTest.Trufas.Add(trufa);

            _contextForTest.Trufas.Add(trufapequena);

            _contextForTest.Trufas.Add(trufamedia);

            _contextForTest.Trufas.Add(trufagrande);



            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateTrufaRepositoryTest()
        {
            //Arrange
            Trufa t = ObjectMother.GetTrufa();
            ITrufaRepository repository = new TrufaRepository();

            //Action
            Trufa newTrufa = repository.Save(t);

            //Assert
            Assert.IsTrue(newTrufa.Id > 0);
            Assert.IsTrue(newTrufa.Sabores[0].Id > 0);
        }

        [TestMethod]
        public void RetrieveTrufaRepositoryTest()
        {
            //Arrange
            ITrufaRepository repository = new TrufaRepository();

            //Action
            Trufa trufa = repository.Get(1);

            //Assert
            Assert.IsNotNull(trufa);
            Assert.IsTrue(trufa.Id > 0);
            Assert.IsFalse(DateTime.Today < (trufa.DataFabricacao));
            Assert.IsFalse(DateTime.Today < (trufa.DataValidade));
            //Assert.IsFalse(int. (trufa.Quantidade));
            Assert.IsFalse(string.IsNullOrEmpty(trufa.Tamanho));
            Assert.IsFalse(double.IsNegativeInfinity(trufa.Valor));

        }

        [TestMethod]
        public void UpdateTrufaRepositoryTest()
        {
            Trufa t = ObjectMother.GetTrufa();
            //Arrange
            ITrufaRepository repository = new TrufaRepository();
            Trufa trufa = ObjectMother.GetTrufa();
            trufa.Id = 1;
            trufa.DataFabricacao = new DateTime(2015, 06, 01);
            trufa.DataValidade = new DateTime(2015, 06, 11);
            trufa.Quantidade = 5;
            trufa.Tamanho = "Grande";
            trufa.Valor = 3.00;
            //trufa.Sabores = null;

            //Action
            var updatedTrufa = repository.Update(trufa);

            //Assert
            _contextForTest = new TrufaContext();
            var persistedTrufa = _contextForTest.Trufas.FirstOrDefault(x => x.Id == 1);
            Assert.IsNotNull(updatedTrufa);
            Assert.AreEqual(updatedTrufa.Id, persistedTrufa.Id);
            Assert.AreEqual(updatedTrufa.DataFabricacao, persistedTrufa.DataFabricacao);
            Assert.AreEqual(updatedTrufa.DataValidade, persistedTrufa.DataValidade);
            Assert.AreEqual(updatedTrufa.Quantidade, persistedTrufa.Quantidade);
            Assert.AreEqual(updatedTrufa.Tamanho, persistedTrufa.Tamanho);
            Assert.AreEqual(updatedTrufa.Valor, persistedTrufa.Valor);

        }

        [TestMethod]
        public void DeleteTrufaRepositoryTest()
        {
            //Arrange
            ITrufaRepository repository = new TrufaRepository();

            //Action
            var deletedTrufa = repository.Delete(1);

            //Assert
            var persistedTrufa = _contextForTest.Trufas.FirstOrDefault(x => x.Id == 1);
            Assert.IsNull(persistedTrufa);

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            //persistedTrufa.Should().BeNull();
        }

        [TestMethod]
        public void RetrieveAllTrufasRepositoryTest()
        {
            //Arrange
            ITrufaRepository repository = new TrufaRepository();

            //Action
            var trufas = repository.GetAll();

            //Assert
            Assert.IsNotNull(trufas);
            Assert.IsTrue(trufas.Count == 4);
        }

    }
}
