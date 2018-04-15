import { Component, Input, OnInit } from '@angular/core';

import { Serie } from '../../models/Serie';

import { BTechServices } from '../../services/BTechServices';
import { Conclusao } from '../../models/Conclusao';

@Component({
    selector: 'serie',
	templateUrl: './serie.component.html',
	styleUrls: ['./serie.component.css']
})
export class SerieComponent implements OnInit {
	@Input() idSerie: number;

	serie: Serie;
	conclusoes: Conclusao[];
	concluido: boolean = this.serie != undefined && this.serie.Conclusoes != undefined ? this.serie.Conclusoes.find(c => new Date(c.DataHoraConclusao).toLocaleDateString() == new Date().toLocaleDateString()) != null : false;

	constructor(private btService: BTechServices) {
	}

	ngOnInit(): void {
		console.log('Serie: ' + this.idSerie);
		this.btService.getSerie(this.idSerie).subscribe(data => {
			this.serie = data.json();
		});
	}

	setConclusao() {
		this.btService.setSerieConcluida(this.serie.Id);
		this.concluido = true;
	}

	getConcluido(): boolean {
		return this.serie != undefined && this.serie.Conclusoes != undefined ? this.serie.Conclusoes.find(c => new Date(c.DataHoraConclusao).toLocaleDateString() == new Date().toLocaleDateString()) != null : false;
	}
}