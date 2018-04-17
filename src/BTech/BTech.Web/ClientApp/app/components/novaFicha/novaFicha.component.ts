import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { Ficha } from '../../models/Ficha';
import { Cliente } from '../../models/Cliente';
import { BTechServices } from '../../services/BTechServices';

@Component({
	selector: 'nova-ficha',
	templateUrl: './novaFicha.component.html'
})
export class NovaFichaComponent implements OnInit {
	
	novaFicha: Ficha = new Ficha();
	@Output() hideFicha = new EventEmitter();
	@Input() idCliente: number;

	private cliente: Cliente;

	constructor(private btService: BTechServices) {}

	ngOnInit(): void {
		this.btService.getClienteById(this.idCliente).subscribe(data => {
			this.cliente = data.json();
		});
	}

	cancelar() {
		this.hideFicha.emit();
	}
}