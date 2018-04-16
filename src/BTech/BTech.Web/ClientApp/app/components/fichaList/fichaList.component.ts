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
	
	constructor(private btService: BTechServices, private appService: AppService, private activatedRoute: ActivatedRoute) {
		
	}

	ngOnInit(): void {
		let usuario: Pessoa = this.appService.usuario.value;

		this.sub = this.activatedRoute.params.subscribe(params => {
			this.idCliente = +params['id'];
			if (this.idCliente) {
				this.btService.getFichaCliente(this.idCliente).subscribe(data => this.fichas.push(data.json()));
			}
			else {
				if (usuario.tipoPessoa == 'Professor') {
					// Listar todas as fichas sob sua responsabilidade
					this.btService.getFichasProfessor(usuario.id).subscribe(data => this.fichas = data.json());
				}
			}
		});

	}
}