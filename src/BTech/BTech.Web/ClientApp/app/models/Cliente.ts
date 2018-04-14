import { Pessoa } from './Pessoa';
import { Ficha } from './Ficha';

export class Cliente extends Pessoa {
	public ContratoAtivo: boolean;
	public Ficha: Ficha;
}