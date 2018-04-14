import { Component, Input, OnInit } from '@angular/core';

import { Serie } from '../../models/Serie';

import { BTechServices } from '../../services/BTechServices';

@Component({
    selector: 'serie',
	templateUrl: './serie.component.html',
	styleUrls: ['./serie.component.css']
})
export class SerieComponent implements OnInit {
	@Input() idSerie: number;

	serie: Serie;

	constructor(private btService: BTechServices) {
	}

	ngOnInit(): void {
		console.log('Serie: ' + this.idSerie);
		this.btService.getSerie(this.idSerie).subscribe(data => this.serie = data.json());
	}
}