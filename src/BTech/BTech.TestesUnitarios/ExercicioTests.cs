using BTech.DataAccess.Entities;
using BTech.Web.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BTech.TestesUnitarios
{
    public class ExercicioTests: BaseTests
    {
		[Fact]
		[Trait("Exercicio", nameof(DeveAlterarCarga))]
		public void DeveAlterarCarga()
		{
			Exercicio exercicio = db.Exercicios.FirstOrDefault();
			ExercicioController exercicioController = new ExercicioController(db);

			JObject novaCarga = new JObject();
			novaCarga.Add("novaCarga", "NovaCarga");

			exercicioController.AlterarCarga(exercicio.Id, novaCarga).Wait();

			Assert.False(exercicio.Ativo);

			Exercicio novoExercicio = db.Exercicios.Where(e => e.NomeExercicio == exercicio.NomeExercicio && e.SerieId == exercicio.SerieId).LastOrDefault();

			Assert.Equal("NovaCarga", novoExercicio.Carga);
			Assert.Equal(exercicio.NomeExercicio, novoExercicio.NomeExercicio);
			Assert.Equal(exercicio.Ordem, novoExercicio.Ordem);
		}
	}
}
