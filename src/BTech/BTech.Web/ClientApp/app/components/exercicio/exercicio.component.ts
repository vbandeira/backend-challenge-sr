import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'exercicio',
    templateUrl: './exercicio.component.html'
})
export class ExercicioComponent {
    @Input() idExercicio: number;
}