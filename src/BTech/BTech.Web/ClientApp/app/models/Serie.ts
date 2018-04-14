import { Exercicio } from './Exercicio';
import { Conclusao } from './Conclusao';

export class Serie {
	public Id: number;
	public TipoSerie: string;
	public Exercicios: Exercicio[];
	public Conclusoes: Conclusao[];
	public Ativa: boolean;
}
