using BTech.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Context
{
    public class BTContext: DbContext
    {
		public BTContext(DbContextOptions<BTContext> options): base(options){}

		public DbSet<Exercicio> Exercicios { get; set; }
		public DbSet<Ficha> Fichas { get; set; }
		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<Serie> Series { get; set; }
    }
}
