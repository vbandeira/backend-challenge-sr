using BTech.DataAccess.Context;
using BTech.DataAccess.Entities;
using BTech.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BTech.TestesUnitarios
{
	public class SerieTests: BaseTests
    {
		[Fact]
		[Trait("Serie",nameof(DeveConcluirSerie))]
		public void DeveConcluirSerie()
		{
			Serie serie = db.Series.FirstOrDefault();
			SerieController serieController = new SerieController(db);
			int conclusoesCount = serie.Conclusoes.Count();

			serieController.ConcluirSerie(serie.Id).Wait();
			Assert.Contains(serie.Conclusoes, c => c.DataHoraConclusao.ToShortDateString() == DateTime.Now.ToShortDateString());
			Assert.Equal(conclusoesCount + 1, serie.Conclusoes.Count());
		}

		[Fact]
		[Trait("Serie", nameof(DeveInserirExericioAsync))]
		public async System.Threading.Tasks.Task DeveInserirExericioAsync()
		{
			Serie serie = db.Series.FirstOrDefault();
			Exercicio novoExercicio = new Exercicio
			{
				Ativo = true,
				Carga = "teste",
				NomeExercicio = "Novo Exercício",
				Ordem = 99,
				Repeticoes = "Rep",
				SerieId = serie.Id,
				Serie = serie
			};

			SerieController serieController = new SerieController(db);
			await serieController.InserirExercicio(serie.Id, novoExercicio);

			Assert.Equal(novoExercicio.NomeExercicio, db.Exercicios.Last().NomeExercicio);
			Assert.Equal(novoExercicio.Carga, db.Exercicios.Last().Carga);
			Assert.Equal(novoExercicio.Ordem, db.Exercicios.Last().Ordem);
			Assert.Equal(novoExercicio.SerieId, db.Exercicios.Last().SerieId);
		}

		[Fact]
		[Trait("Serie", nameof(DeveExcluirExercicioAsync))]
		public async System.Threading.Tasks.Task DeveExcluirExercicioAsync()
		{
			Serie serie = db.Series.FirstOrDefault();
			Exercicio exercicio = serie.Exercicios.FirstOrDefault();
			SerieController serieController = new SerieController(db);

			await serieController.ExcluirExercicio(serie.Id, exercicio.Id);
			
			Assert.Equal(0, serie.Exercicios.Count(e => e.Id == exercicio.Id));

		}

		[Fact]
		[Trait("Serie", nameof(DeveInserirSerie))]
		public void DeveInserirSerie()
		{
			Assert.True(false, "Não implementado");
		}

		[Fact]
		[Trait("Serie", nameof(DeveExcluirSerie))]
		public void DeveExcluirSerie()
		{
			Assert.True(false, "Não implementado");
		}
	}
}
