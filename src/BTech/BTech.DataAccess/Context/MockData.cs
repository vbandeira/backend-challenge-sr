using BTech.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTech.DataAccess.Context
{
    public static class MockData
    {
		public static void AddMockData(BTContext context)
		{
			AddFicha(context);
			AddPessoas(context);
		}

		private static void AddPessoas(BTContext context)
		{
			Ficha ficha = context.Fichas.First();

			context.Clientes.Add(new Entities.Cliente
			{
				Login = "cliente1",
				Nome = "Cliente 1",
				ContratoAtivo = true,
				Ficha = ficha,
				TipoPessoa = TipoPessoa.Cliente
			});

			context.SaveChanges();
		}

		private static void AddFicha(BTContext context)
		{
			Pessoa professor = new Entities.Pessoa
			{
				Login = "professor1",
				Nome = "Professor 1",
				TipoPessoa = TipoPessoa.Professor
			};

			context.Pessoas.Add(professor);
			context.SaveChanges();

			context.Fichas.Add(new Entities.Ficha
			{
				InicioPeriodo = DateTime.Now,
				TerminoPeriodo = DateTime.Now.AddDays(7),
				Professor = context.Pessoas.First(p => p == professor),
				Series = new List<Entities.Serie>
				{
					new Entities.Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = Entities.TipoSerie.A,
						Exercicios = new List<Entities.Exercicio>
						{
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca scott com barra",
								Repeticoes = "3 x 8 ~ 10",
								Carga = "∞",
								Ordem = 1
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca alternada inclinado",
								Ordem = 2
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca direta (pegada fechada)",
								Ordem = 3
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca hammer",
								Ordem = 4
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino com pegada invertida",
								Ordem = 5
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps francês",
								Ordem = 6
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps patada",
								Ordem = 7
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps no pulley",
								Ordem = 8
							}
						}
					},
					new Entities.Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = Entities.TipoSerie.B,
						Exercicios = new List<Entities.Exercicio>
						{
							new Entities.Exercicio
							{
								NomeExercicio = "Adutor/Abdutor",
								Ordem = 1
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Leg Press",
								Ordem = 2
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Cadeira extensora/flexora",
								Ordem = 3
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Panturrilha",
								Ordem = 4
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Elevação lateral",
								Ordem = 5
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Desenvolvimento ombro",
								Ordem = 6
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Encolhimento de ombros com Halteres",
								Ordem = 7
							}
						}
					},
					new Entities.Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = Entities.TipoSerie.C,
						Exercicios = new List<Entities.Exercicio>
						{
							new Entities.Exercicio
							{
								NomeExercicio = "Supino reto",
								Ordem = 1
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino inclinado",
								Ordem = 2
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino declinado",
								Ordem = 3
							}
						}
					}
				}
			});

			context.SaveChanges();
		}
    }
}
