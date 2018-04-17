import { Serie } from './Serie';
import { Pessoa } from './Pessoa';
import { Cliente } from './Cliente';

export class Ficha 
{
	public id: number ;
	public series: Serie[]  ;
	public inicioPeriodo: Date ;
	public terminoPeriodo: Date ;
	public professor: Pessoa ;
	public cliente: Cliente ; 
}