using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Entities
{
	public class Ficha
    {
		public int Id { get; set; }
		public List<Serie> Series { get; set; }
		public DateTime InicioPeriodo { get; set; }
		public DateTime TerminoPeriodo { get; set; }
		public Pessoa Professor { get; set; }

		public Cliente Cliente { get; set; }
    }
}
