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
	concluido: boolean;

	constructor(private btService: BTechServices) {
	}

	ngOnInit(): void {
		console.log('Serie: ' + this.idSerie);
		this.btService.getSerie(this.idSerie).subscribe(data => {
			this.serie = data.json();
			let conclusoes :Conclusao[] = (<Serie>data.json()).Conclusoes;
			this.concluido = conclusoes != undefined ? conclusoes.find(c => new Date(c.DataHoraConclusao).toLocaleDateString() == new Date().toLocaleDateString()) != null : false;
			//debugger;
		});
	}

	setConclusao() {
		this.btService.setSerieConcluida(this.serie.Id);
	}
}