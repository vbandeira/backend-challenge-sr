//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BTech.DataAccess.Entities
//{
//	public enum TipoSerie
//	{
//		A,
//		B,
//		C
//	}

//	public class FichaSerie : Serie
//	{
//		[JsonConverter(typeof(StringEnumConverter))]
//		public TipoSerie TipoSerie { get; set; }

//		public int FichaId { get; set; }
//		public List<Conclusao> Conclusoes { get; set; }

//		public virtual Ficha Ficha { get; set; }

//	}
//}
