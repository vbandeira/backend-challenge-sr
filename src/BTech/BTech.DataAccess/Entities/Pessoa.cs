using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Entities
{

	public enum TipoPessoa
	{
		Administrador,
		Cliente,
		Professor
	}

    public class Pessoa
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Login { get; set; }
		public TipoPessoa TipoPessoa { get; set; }
		public bool? ContratoAtivo { get; set; }
		public Ficha Ficha { get; set; }
    }
}
