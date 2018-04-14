import { Component, Input, OnInit } from '@angular/core';

import { BTechServices } from '../../services/BTechServices';
import { Ficha } from '../../models/Ficha';

@Component({
	selector: 'ficha',
	templateUrl: './ficha.component.html'
})
export class FichaComponent implements OnInit {
	@Input() idFicha: number;

	ficha: Ficha;

	constructor(private btService: BTechServices) { }

	ngOnInit(): void {
		console.log('Ficha: ' + this.idFicha);
		this.btService.getFicha(this.idFicha).subscribe(data => this.ficha = data.json());
	}
}