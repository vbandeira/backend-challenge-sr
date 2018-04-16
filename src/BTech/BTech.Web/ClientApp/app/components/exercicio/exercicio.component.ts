import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { Exercicio } from '../../models/Exercicio';
import { BTechServices } from '../../services/BTechServices';
import { Router } from '@angular/router';


@Component({
    selector: '[exercicio]',
    templateUrl: './exercicio.component.html'
})
export class ExercicioComponent implements OnInit {
	
	@Input() exercicio: Exercicio;
	@Input() professor: boolean;
	@Input() idSerie: number;

	@Output() refresh = new EventEmitter();
	@Output() remove = new EventEmitter();

	edit: boolean = false;
	novo: boolean = false;

	novaCarga: string; 

	constructor(private btService: BTechServices, private router: Router) {
	}

	ngOnInit(): void {
		
		if (this.exercicio.id == undefined)
			this.novo = true;
	}

	toggleEdit() {
		this.edit = !this.edit;
		this.novaCarga = this.exercicio.carga;
	};

	saveCarga() {
		this.btService.setAlterarCarga(this.exercicio.id, this.novaCarga.toString()).subscribe(data => {
			this.exercicio = data.json();
			this.edit = false;
		});
	}

	removeExercicio() {
		if (this.novo) {
			this.remove.emit();
		}
		else {
			this.btService.deleteExercicio(this.exercicio.id).subscribe(data => {
				this.refresh.emit();
			});
		}
	}

	saveExercicio() {
		this.exercicio.carga = this.novaCarga;
		this.exercicio.Ativo = true;
		this.btService.inserirExercicio(this.idSerie, this.exercicio).subscribe(() => {
			this.refresh.emit();
		});
	}
}