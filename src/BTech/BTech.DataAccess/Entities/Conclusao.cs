using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Entities
{
    public class Conclusao
    {
		public int Id { get; set; }
		public Serie Serie { get; set; }
		public DateTime DataHoraConclusao { get; set; }
    }
}
