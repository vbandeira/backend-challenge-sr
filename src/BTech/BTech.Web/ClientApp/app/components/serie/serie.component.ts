import { Component, Input, OnInit } from '@angular/core';

import { Serie } from '../../models/Serie';

import { BTechServices } from '../../services/BTechServices';
import { Conclusao } from '../../models/Conclusao';
import { Exercicio } from '../../models/Exercicio';

@Component({
    selector: 'serie',
	templateUrl: './serie.component.html',
	styleUrls: ['./serie.component.css']
})
export class SerieComponent implements OnInit {
	@Input() idSerie: number;
	@Input() professor: boolean;

	serie: Serie;
	conclusoes: Conclusao[];
	concluido: boolean = this.serie != undefined && this.serie.conclusoes != undefined ? this.serie.conclusoes.find(c => new Date(c.DataHoraConclusao).toLocaleDateString() == new Date().toLocaleDateString()) != null : false;

	constructor(private btService: BTechServices) {
	}

	ngOnInit(): void {
		if (this.idSerie != undefined) {
			console.log('Serie: ' + this.idSerie);
			this.loadData();
		}
	}

	setConclusao() {
		this.btService.setSerieConcluida(this.serie.id);
		this.concluido = true;
	}

	getConcluido(): boolean {
		return this.serie != undefined && this.serie.conclusoes != undefined ? this.serie.conclusoes.find(c => new Date(c.DataHoraConclusao).toLocaleDateString() == new Date().toLocaleDateString()) != null : false;
	}

	loadData() {
		this.btService.getSerie(this.idSerie).subscribe(data => {
			this.serie = data.json();
		});
	}

	addExercicio() {
		this.serie.exercicios.push(new Exercicio());
	}

	removeNovo() {
		this.serie.exercicios.pop();
	}
}