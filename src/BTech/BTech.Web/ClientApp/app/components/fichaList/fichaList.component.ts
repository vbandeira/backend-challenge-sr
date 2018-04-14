import { Component } from '@angular/core';

import { BTechServices } from '../../services/BTechServices';
import { Ficha } from '../../models/Ficha';

@Component({
    selector: 'fichaList',
    templateUrl: './fichaList.component.html'
})
export class FichaListaComponent {
	fichas: Ficha[];

	constructor(private btService: BTechServices) {
		btService.getFichas().subscribe(data => this.fichas = data.json());
	}
}