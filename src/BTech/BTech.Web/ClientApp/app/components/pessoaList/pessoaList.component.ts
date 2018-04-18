import { Component, Output, OnInit, EventEmitter } from '@angular/core';

import { Pessoa } from '../../models/Pessoa';
import { BTechServices } from '../../services/BTechServices';
import { Cliente } from '../../models/Cliente';
import { Ficha } from '../../models/Ficha';

@Component({
	selector: 'pessoaList',
	templateUrl: './pessoaList.component.html'
})
export class PessoaListComponent implements OnInit {
	
	pessoas: Pessoa[];
	cliente: Cliente = new Cliente();
	novoCliente: boolean = false;
	editCliente: boolean = false;

	campoBusca: string;

	constructor(private btService: BTechServices) { }

	private updateClientes() {
		this.btService.getClientes().subscribe(data => this.pessoas = data.json());
	}

	ngOnInit(): void {
		this.updateClientes();
	}

	NovoCliente() {
		this.novoCliente = !this.novoCliente;
	}

	cancelar() {
		this.novoCliente = false;
		this.editCliente = false;
	}

	SalvarCliente() {
		if (this.novoCliente) {
			this.btService.novoCliente(this.cliente).subscribe(() => {
				this.updateClientes();
				this.novoCliente = false;
			});
		}

		if (this.editCliente) {
			this.btService.editCliente(this.cliente).subscribe(() => {
				this.updateClientes()
				this.editCliente = false;
			});
		};
	}

	editPessoa(pessoa: Cliente) {
		this.editCliente = true;
		this.cliente = { ...pessoa };
	}

	searchCliente() {
		this.btService.searchCliente(this.campoBusca).subscribe(data => this.pessoas = data.json());
	}
}