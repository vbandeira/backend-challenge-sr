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

			context.Pessoas.Add(new Entities.Pessoa
			{
				Login = "cliente1",
				Nome = "Cliente 1",
				ContratoAtivo = true,
				TipoPessoa = Entities.TipoPessoa.Cliente,
				Ficha = ficha
			});

			context.Pessoas.Add(new Entities.Pessoa
			{
				Login = "professor1",
				Nome = "Professor 1",
				TipoPessoa = Entities.TipoPessoa.Professor
			});

			context.Pessoas.Add(new Entities.Pessoa
			{
				Login = "admin",
				Nome = "Administrador",
				TipoPessoa = Entities.TipoPessoa.Administrador
			});

			context.SaveChanges();
		}

		private static void AddFicha(BTContext context)
		{
			context.Fichas.Add(new Entities.Ficha
			{
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
								Carga = "∞"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca alternada inclinado"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca direta (pegada fechada)"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca hammer"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino com pegada invertida"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps francês"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps patada"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps no pulley"
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
								NomeExercicio = "Adutor/Abdutor"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Leg Press"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Cadeira extensora/flexora"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Panturrilha"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Elevação lateral"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Desenvolvimento ombro"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Encolhimento de ombros com Halteres"
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
								NomeExercicio = "Supino reto"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino inclinado"
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino declinado"
							}
						}
					}
				}
			});

			context.SaveChanges();
		}
    }
}
