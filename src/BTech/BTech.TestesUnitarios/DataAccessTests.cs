using BTech.DataAccess.Context;
using BTech.Web.Controllers;
using System;
using System.Linq;
using Xunit;

namespace BTech.TestesUnitarios
{
    public class DataAccessTests: BaseTests
    {
		[Fact]
		[Trait("Acesso a Dados", nameof(DeveCarregarDadosMock))]
		public void DeveCarregarDadosMock()
        {
			Assert.NotEqual(0, db.Pessoas.Count());
        }

		[Fact]
		[Trait("Acesso a Dados", nameof(DeveCriarUsuario))]
		public void DeveCriarUsuario()
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
