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
			Ficha ficha1 = context.Fichas.First();
			Ficha ficha2 = context.Fichas.Last();

			context.Clientes.Add(new Entities.Cliente
			{
				Login = "cliente1",
				Nome = "Cliente 1",
				ContratoAtivo = true,
				Ficha = ficha1,
				TipoPessoa = TipoPessoa.Cliente
			});

			context.Clientes.Add(new Entities.Cliente
			{
				Login = "cliente2",
				Nome = "Cliente 2",
				ContratoAtivo = true,
				Ficha = ficha2,
				TipoPessoa = TipoPessoa.Cliente
			});

			context.Pessoas.Add(new Pessoa
			{
				Login = "professor2",
				Nome = "Professor 2",
				TipoPessoa = TipoPessoa.Professor
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
						Exercicios = new List<Entities.Exercicio>{
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca scott com barra",
								Repeticoes = "3 x 8 ~ 10",
								Carga = "∞",
								Ordem = 1,
								Ativo = false
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca alternada inclinado",
								Ordem = 2,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca direta (pegada fechada)",
								Ordem = 3,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca hammer",
								Ordem = 4,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino com pegada invertida",
								Ordem = 5,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps francês",
								Ordem = 6,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps patada",
								Ordem = 7,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps no pulley",
								Ordem = 8,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca scott com barra",
								Repeticoes = "3 x 8 ~ 10",
								Carga = "1",
								Ordem = 1,
								Ativo = true
							},
						}
					},
					new Entities.Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = Entities.TipoSerie.B,
						Exercicios = new List<Entities.Exercicio>{
							new Entities.Exercicio
							{
								NomeExercicio = "Adutor/Abdutor",
								Ordem = 1,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Leg Press",
								Ordem = 2,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Cadeira extensora/flexora",
								Ordem = 3,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Panturrilha",
								Ordem = 4,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Elevação lateral",
								Ordem = 5,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Desenvolvimento ombro",
								Ordem = 6,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Encolhimento de ombros com Halteres",
								Ordem = 7,
								Ativo = true
							}
						}
					},
					new Entities.Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = Entities.TipoSerie.C,
						Exercicios = new List<Entities.Exercicio>{
							new Entities.Exercicio
							{
								NomeExercicio = "Supino reto",
								Ordem = 1,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino inclinado",
								Ordem = 2,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino declinado",
								Ordem = 3,
								Ativo = true
							}
						}
					}
				}
			});

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
						TipoSerie = Entities.TipoSerie.B,
						Exercicios = new List<Entities.Exercicio>{
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca scott com barra",
								Repeticoes = "3 x 8 ~ 10",
								Carga = "∞",
								Ordem = 1,
								Ativo = false
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca alternada inclinado",
								Ordem = 2,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca direta (pegada fechada)",
								Ordem = 3,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca hammer",
								Ordem = 4,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino com pegada invertida",
								Ordem = 5,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps francês",
								Ordem = 6,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps patada",
								Ordem = 7,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Tríceps no pulley",
								Ordem = 8,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Rosca scott com barra",
								Repeticoes = "3 x 8 ~ 10",
								Carga = "1",
								Ordem = 1,
								Ativo = true
							}
						}
					},
					new Entities.Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = Entities.TipoSerie.C,
						Exercicios = new List<Entities.Exercicio>{
							new Entities.Exercicio
							{
								NomeExercicio = "Adutor/Abdutor",
								Ordem = 1,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Leg Press",
								Ordem = 2,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Cadeira extensora/flexora",
								Ordem = 3,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Panturrilha",
								Ordem = 4,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Elevação lateral",
								Ordem = 5,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Desenvolvimento ombro",
								Ordem = 6,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Encolhimento de ombros com Halteres",
								Ordem = 7,
								Ativo = true
							}
						}
					},
					new Entities.Serie
					{
						Ativa = true,
						Conclusoes = new List<Conclusao>(),
						TipoSerie = Entities.TipoSerie.A,
						Exercicios = new List<Entities.Exercicio>{
							new Entities.Exercicio
							{
								NomeExercicio = "Supino reto",
								Ordem = 1,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino inclinado",
								Ordem = 2,
								Ativo = true
							},
							new Entities.Exercicio
							{
								NomeExercicio = "Supino declinado",
								Ordem = 3,
								Ativo = true
							}
						}
					}
				}
			});

			context.SaveChanges();
			
			Serie serie = context.Series.First();
			serie.Conclusoes.Add(new Conclusao
			{
				DataHoraConclusao = DateTime.Now,
				Serie = serie
			});
			context.SaveChanges();
		}
    }
}
