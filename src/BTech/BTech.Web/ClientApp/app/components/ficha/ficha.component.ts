import { Component, Input, OnInit } from '@angular/core';

import { BTechServices } from '../../services/BTechServices';
import { AppService } from '../../services/AppService';
import { Ficha } from '../../models/Ficha';

@Component({
	selector: 'ficha',
	templateUrl: './ficha.component.html'
})
export class FichaComponent implements OnInit {
	@Input() idFicha: number;

	ficha: Ficha;
	professor: boolean = false;

	constructor(private btService: BTechServices, private appService: AppService) {
		this.professor = appService.usuario.value.tipoPessoa == 'Professor';
	}

	ngOnInit(): void {
		console.log('Ficha: ' + this.idFicha);
		this.btService.getFicha(this.idFicha).subscribe((data) => {
			this.ficha = data.json()
		}, (error) => {
			debugger;
			///if (error.status == 404)

		});
	}
}