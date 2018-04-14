import { Serie } from './Serie';
import { Pessoa } from './Pessoa';
import { Cliente } from './Cliente';

export class Ficha 
{
	public Id: number ;
	public Series: Serie[]  ;
	public InicioPeriodo: Date ;
	public TerminoPeriodo: Date ;
	public Professor: Pessoa ;
	public Cliente: Cliente ; 
}