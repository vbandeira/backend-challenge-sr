import { Component, Input} from '@angular/core';

import { Pessoa } from '../../models/Pessoa';

@Component({
    selector: 'pessoa',
    templateUrl: './pessoa.component.html'
})
export class PessoaComponent {
	@Input() pessoa: Pessoa;
	
}