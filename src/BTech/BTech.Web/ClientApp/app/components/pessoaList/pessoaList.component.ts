import { Component, Input, OnInit } from '@angular/core';

import { Pessoa } from '../../models/Pessoa';
import { BTechServices } from '../../services/BTechServices';

@Component({
	selector: 'pessoaList',
	templateUrl: './pessoaList.component.html'
})
export class PessoaListComponent implements OnInit {
	pessoas: Pessoa[];

	constructor(private btService: BTechServices) { }

	ngOnInit(): void {
		this.btService.getClientes().subscribe(data => this.pessoas = data.json());
	}
}