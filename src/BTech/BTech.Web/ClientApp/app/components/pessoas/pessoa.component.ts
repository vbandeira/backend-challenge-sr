import { Component, Input, Output, EventEmitter} from '@angular/core';

import { Pessoa } from '../../models/Pessoa';

@Component({
    selector: 'pessoa',
    templateUrl: './pessoa.component.html'
})
export class PessoaComponent {
	@Input() pessoa: Pessoa;
	@Output() edit = new EventEmitter();

	editPessoa() {
		this.edit.emit(this.pessoa);
	}
}