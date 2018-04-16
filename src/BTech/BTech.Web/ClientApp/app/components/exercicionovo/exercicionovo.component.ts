import { Component, Input } from '@angular/core';
import { BTechServices } from '../../services/BTechServices';

@Component({
	selector: '[exercicio-novo]',
	templateUrl: './exercicionovo.component.html'
})
export class ExercicioNovoComponent {
	@Input() idSerie: number;

	constructor(private btService: BTechServices) {}
}