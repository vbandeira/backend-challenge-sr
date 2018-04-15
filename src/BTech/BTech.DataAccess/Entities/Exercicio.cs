using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Entities
{
    public class Exercicio
    {
		public int Id { get; set; }
		public string NomeExercicio { get; set; }
		public string Repeticoes { get; set; }
		public string Carga { get;  set; }
		public int Ordem { get; set; }
		public bool Ativo { get; set; }
		public int? SerieId { get; set; }
		public DateTime DataCadastro { get; set; } = DateTime.Now;

		public virtual Serie Serie { get; set; }
    }
}
