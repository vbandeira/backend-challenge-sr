import { Pessoa } from './Pessoa';
import { Ficha } from './Ficha';

export class Cliente extends Pessoa {
	public contratoAtivo: boolean;
	public ficha: Ficha;
	public matricula: string;
}