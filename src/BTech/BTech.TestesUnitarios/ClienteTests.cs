using BTech.DataAccess.Entities;
using BTech.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BTech.TestesUnitarios
{
    public class ClienteTests: BaseTests
    {
		[Fact]
		[Trait("Serie", nameof(DeveInserirCliente))]
		public void DeveInserirCliente()
		{
			Cliente cliente = new Cliente
			{
				ContratoAtivo = true,
				Login = "cliente",
				Matricula = "0000",
				Nome = "Cliente Teste",
				TipoPessoa = TipoPessoa.Cliente
			};

			ClienteController clienteController = new ClienteController(db);
			clienteController.PostCliente(cliente).Wait();

			Cliente teste = db.Clientes.Last();
			Assert.Equal(cliente, teste);
		}

		[Fact]
		[Trait("Serie", nameof(DeveAlterarCliente))]
		public void DeveAlterarCliente()
		{
			Cliente cliente = db.Clientes.First();
			cliente.Nome = "Teste";

			ClienteController clienteController = new ClienteController(db);
			clienteController.PutCliente(cliente.Id, cliente).Wait();

			Assert.Equal("Teste", db.Clientes.First().Nome);
		}

		[Theory]
		[InlineData("Cliente 1")]
		[InlineData("00001")]
		[Trait("Serie", nameof(DevePesquisarClienteAsync))]
		public async System.Threading.Tasks.Task DevePesquisarClienteAsync(string inBusca)
		{
			Cliente cliente = db.Clientes.First();

			ClienteController clienteController = new ClienteController(db);

			var result = await clienteController.BuscarCliente(inBusca);
			var resultado = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value;
			
			Assert.Equal(cliente, resultado);
		}
	}
}
