import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { BTechServices } from '../../services/BTechServices';
import { AppService } from '../../services/AppService';
import { Ficha } from '../../models/Ficha';
import { Pessoa } from '../../models/Pessoa';


@Component({
    selector: 'fichaList',
    templateUrl: './fichaList.component.html'
})
export class FichaListaComponent implements OnInit {
	
	fichas: Ficha[] = new Array<Ficha>();
	private sub: any;
	idCliente: number;

	fichasVazia: boolean = false;
	novaFicha: boolean = false;
	
	constructor(private btService: BTechServices, private appService: AppService, private activatedRoute: ActivatedRoute) {
		
	}

	ngOnInit(): void {
		let usuario: Pessoa = this.appService.usuario.value;

		this.sub = this.activatedRoute.params.subscribe(params => {
			this.idCliente = +params['id'];
			if (this.idCliente) {
				this.btService.getFichaCliente(this.idCliente).subscribe(data => {
					this.fichas.push(data.json())
				},
				error => {
					if (error.status == 404)
						this.fichasVazia = true;
				});
			}
			else {
				if (usuario.tipoPessoa == 'Professor') {
					this.btService.getFichas().subscribe(data => this.fichas = data.json());
				}
			}
		});
	}

	adicionarFicha() {
		this.novaFicha = true;
	}

	hideFicha() {
		this.novaFicha = false;
	}
}