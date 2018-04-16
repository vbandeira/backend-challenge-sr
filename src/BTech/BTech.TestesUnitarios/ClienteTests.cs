using System;
using System.Collections.Generic;
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
			Assert.True(false, "Não implementado");
		}

		[Fact]
		[Trait("Serie", nameof(DeveAlterarCliente))]
		public void DeveAlterarCliente()
		{
			Assert.True(false, "Não implementado");
		}
	}
}
