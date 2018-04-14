import { Component } from '@angular/core';

import { Pessoa } from '../../models/Pessoa';
import { AppService } from '../../services/AppService';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
	usuarioLogado: Observable<Pessoa>;

	constructor(private appService: AppService) {
		this.usuarioLogado = appService.getUserLogged();
	}
}
