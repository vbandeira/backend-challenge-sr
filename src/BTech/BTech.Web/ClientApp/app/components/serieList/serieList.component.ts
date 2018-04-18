import { Component, OnInit } from '@angular/core';

import { BTechServices } from '../../services/BTechServices';
import { Serie } from '../../models/Serie';
import { AppService } from '../../services/AppService';

@Component({
	selector: 'serieList',
	templateUrl: './serieList.component.html'
})
export class SerieListComponent implements OnInit {
	
	series: Serie[];
	professor: boolean = false;

	constructor(private btService: BTechServices, private appService: AppService) {
		this.professor = appService.usuario.value.tipoPessoa == 'Professor';
	}

	ngOnInit(): void {
		this.btService.getSeries().subscribe(data => this.series = data.json());
	}
}