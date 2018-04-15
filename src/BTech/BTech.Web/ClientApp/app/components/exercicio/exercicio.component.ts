import { Component, Input, OnInit } from '@angular/core';
import { Exercicio } from '../../models/Exercicio';
import { BTechServices } from '../../services/BTechServices';


@Component({
    selector: '[exercicio]',
    templateUrl: './exercicio.component.html'
})
export class ExercicioComponent {
	@Input() exercicio: Exercicio;

	edit: boolean = false;
	novaCarga: string; 

	constructor(private btService: BTechServices) {}

	toggleEdit() {
		this.edit = !this.edit;
		this.novaCarga = this.exercicio.carga;
	};

	saveCarga() {
		debugger;
		this.btService.setAlterarCarga(this.exercicio.id, this.novaCarga.toString()).subscribe(data => {
			this.exercicio = data.json();
			this.edit = false;
		});
	}
}