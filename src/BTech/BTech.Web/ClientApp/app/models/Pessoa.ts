import { Ficha } from './Ficha';

export class Pessoa {
	id: number;
	nome: string;
	login: string;
	tipoPessoa: string;
	contratoAtivo: boolean;
	ficha: Ficha;
}