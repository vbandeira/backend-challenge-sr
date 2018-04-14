using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Entities
{
    public class Cliente: Pessoa
    {
		public bool? ContratoAtivo { get; set; }
		public Ficha Ficha { get; set; }
	}
}
