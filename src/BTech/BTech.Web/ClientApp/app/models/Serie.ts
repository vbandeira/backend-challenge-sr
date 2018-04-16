import { Exercicio } from './Exercicio';
import { Conclusao } from './Conclusao';

export class Serie {
	public id: number;
	public tipoSerie: string;
	public exercicios: Exercicio[];
	public conclusoes: Conclusao[];
	public ativa: boolean;
}
