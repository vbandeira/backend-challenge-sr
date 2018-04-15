using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Entities
{
	public enum TipoPessoa
	{
		Cliente,
		Professor
	}

    public class Pessoa
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Login { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public TipoPessoa TipoPessoa { get; set; }
    }
}
