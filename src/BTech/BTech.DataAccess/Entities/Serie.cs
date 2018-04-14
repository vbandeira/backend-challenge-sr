using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Entities
{
	public enum TipoSerie
	{
		A,
		B,
		C
	}

	public class Serie
    {
		public int Id { get; set; }
		public TipoSerie TipoSerie { get; set; }
		public List<Exercicio> Exercicios { get; set; }
		public List<Conclusao> Conclusoes { get; set; }
		public bool Ativa { get; set; }
    }
}
