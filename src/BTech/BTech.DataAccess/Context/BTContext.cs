using BTech.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTech.DataAccess.Context
{
    public class BTContext: DbContext
    {
		public BTContext() {}
		public BTContext(DbContextOptions<BTContext> options): base(options){}

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Exercicio> Exercicios { get; set; }
		public DbSet<Ficha> Fichas { get; set; }
		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<Serie> Series { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
				builder.UseInMemoryDatabase();
		}
    }
}
