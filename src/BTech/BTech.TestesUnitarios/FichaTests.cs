using BTech.DataAccess.Entities;
using BTech.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BTech.TestesUnitarios
{
    public class FichaTests: BaseTests
    {
		[Fact]
		public async System.Threading.Tasks.Task DeveObterFichaAsync()
		{
			FichaController fichaController = new FichaController(db);
			Cliente cliente = db.Clientes.FirstOrDefault();
			var result = await fichaController.GetFichaCliente(cliente.Id);
			var ficha = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value;
			Assert.NotNull(ficha);
			Assert.IsType<Ficha>(ficha);
		}

		[Fact]
		public async System.Threading.Tasks.Task DeveMontarFichaAsync()
		{
			Ficha ficha = new Ficha
			{
				Cliente = db.Clientes.First(),
				Professor = db.Pessoas.First(),
				InicioPeriodo = DateTime.Now,
				TerminoPeriodo = DateTime.Now.AddDays(1),
				Series = new List<Serie>
				{
					new Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = TipoSerie.A,
						Exercicios = new List<Exercicio>
						{
							new Exercicio
							{
								Ativo=true,
								NomeExercicio = "Ex1"
							}
						}
					}
				}
			};

			FichaController fichaController = new FichaController(db);
			await fichaController.PostFicha(ficha);

			Assert.Contains(ficha, db.Fichas);
		}

		[Fact]
		public async System.Threading.Tasks.Task DeveFalharMontarFichaSemContratoAsync()
		{
			db.Clientes.First().ContratoAtivo = false;

			Ficha ficha = new Ficha
			{
				Cliente = db.Clientes.First(),
				Professor = db.Pessoas.First(),
				InicioPeriodo = DateTime.Now,
				TerminoPeriodo = DateTime.Now.AddDays(1),
				Series = new List<Serie>
				{
					new Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = TipoSerie.A,
						Exercicios = new List<Exercicio>
						{
							new Exercicio
							{
								Ativo=true,
								NomeExercicio = "Ex1"
							}
						}
					}
				}
			};

			FichaController fichaController = new FichaController(db);
			IActionResult result = await fichaController.PostFicha(ficha);

			Assert.DoesNotContain(ficha, db.Fichas);
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		public async System.Threading.Tasks.Task DeveFalharMontarFichaSemSerieAsync()
		{
			Ficha ficha = new Ficha
			{
				Cliente = db.Clientes.First(),
				Professor = db.Pessoas.First(),
				InicioPeriodo = DateTime.Now,
				TerminoPeriodo = DateTime.Now.AddDays(1),
				Series = new List<Serie>()
			};

			FichaController fichaController = new FichaController(db);
			IActionResult result = await fichaController.PostFicha(ficha);
			
			Assert.DoesNotContain(ficha, db.Fichas);
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		[Trait("Ficha", nameof(DeveInserirFicha))]
		public void DeveInserirFicha()
		{
			Ficha ficha = new Ficha
			{
				Cliente = db.Clientes.First(),
				Professor = db.Pessoas.First(),
				InicioPeriodo = DateTime.Now,
				TerminoPeriodo = DateTime.Now.AddDays(7),
				Series = new List<Serie>()
				{
					new Serie
					{
						Ativa=true,
						Conclusoes = new List<Conclusao>(),
						Exercicios = new List<Exercicio>(),
						TipoSerie = TipoSerie.A
					}
				}
			};

			FichaController fichaController = new FichaController(db);
			fichaController.PostFicha(ficha).Wait();

			Ficha resultado = db.Fichas.Last();

			Assert.Equal(resultado, ficha);
		}

		[Fact]
		[Trait("Ficha", nameof(DeveFalharAoInserirFichaSemClienteAsync))]
		public async System.Threading.Tasks.Task DeveFalharAoInserirFichaSemClienteAsync()
		{
			Ficha ficha = new Ficha
			{
				Professor = db.Pessoas.First(),
				InicioPeriodo = DateTime.Now,
				TerminoPeriodo = DateTime.Now.AddDays(7),
				Series = new List<Serie>()
				{
					new Serie
					{
						Ativa=true,
						Conclusoes = new List<Conclusao>(),
						Exercicios = new List<Exercicio>(),
						TipoSerie = TipoSerie.A
					}
				}
			};

			FichaController fichaController = new FichaController(db);
			IActionResult result = await fichaController.PostFicha(ficha);

			Assert.DoesNotContain(ficha, db.Fichas);
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		[Trait("Ficha", nameof(DeveFalharAoInserirFichaSemProfessorAsync))]
		public async System.Threading.Tasks.Task DeveFalharAoInserirFichaSemProfessorAsync()
		{
			Ficha ficha = new Ficha
			{
				Cliente = db.Clientes.First(),
				InicioPeriodo = DateTime.Now,
				TerminoPeriodo = DateTime.Now.AddDays(7),
				Series = new List<Serie>()
				{
					new Serie
					{
						Ativa=true,
						Conclusoes = new List<Conclusao>(),
						Exercicios = new List<Exercicio>(),
						TipoSerie = TipoSerie.A
					}
				}
			};

			FichaController fichaController = new FichaController(db);
			IActionResult result = await fichaController.PostFicha(ficha);

			Assert.DoesNotContain(ficha, db.Fichas);
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		[Trait("Serie", nameof(DeveExcluirFicha))]
		public void DeveExcluirFicha()
		{
			Ficha ficha = db.Fichas.Last();

			FichaController fichaController = new FichaController(db);
			fichaController.DeleteFicha(ficha.Id).Wait();

			Assert.DoesNotContain(ficha, db.Fichas);
		}
	}
}
