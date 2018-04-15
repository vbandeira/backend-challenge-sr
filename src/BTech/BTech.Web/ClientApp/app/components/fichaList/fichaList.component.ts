import { Component } from '@angular/core';

import { BTechServices } from '../../services/BTechServices';
import { AppService } from '../../services/AppService';
import { Ficha } from '../../models/Ficha';
import { Pessoa } from '../../models/Pessoa';

@Component({
    selector: 'fichaList',
    templateUrl: './fichaList.component.html'
})
export class FichaListaComponent {
	fichas: Ficha[] = new Array<Ficha>();

	constructor(private btService: BTechServices, private appService: AppService) {
		let usuario: Pessoa = appService.usuario.value;
		
		if (usuario.tipoPessoa == 'Professor') {
			// Listar todas as fichas sob sua responsabilidade
			btService.getFichasProfessor(usuario.id).subscribe(data => this.fichas = data.json());
		}
		else {
			btService.getFichaCliente(usuario.id).subscribe(data => this.fichas.push(data.json()));
		}

		
	}
}