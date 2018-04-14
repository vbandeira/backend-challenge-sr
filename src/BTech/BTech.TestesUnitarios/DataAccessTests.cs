using BTech.DataAccess.Context;
using BTech.Web.Controllers;
using System;
using System.Linq;
using Xunit;

namespace BTech.TestesUnitarios
{
    public class DataAccessTests
    {
		BTContext db;

		public DataAccessTests()
		{
			db = new BTContext();
			MockData.AddMockData(db);
		}

        [Fact]
        public void ShouldContainMockData()
        {
			Assert.Equal(3, db.Pessoas.Count());
        }

		[Fact]
		public void ShouldCreateCliente()
		{
			PessoaController pessoaController = new PessoaController(db);
			int pessoasCount = pessoaController.GetPessoas().Count();
			pessoaController.PostPessoa(new DataAccess.Entities.Pessoa
			{
				Nome = "Teste",
				Login = "teste"
			}).Wait();
			Assert.Equal(pessoasCount + 1, pessoaController.GetPessoas().Count());
		}
    }
}
