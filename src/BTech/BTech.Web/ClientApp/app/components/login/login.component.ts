import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { BTechServices } from '../../services/BTechServices';
import { AppService } from '../../services/AppService';
import { Pessoa } from '../../models/Pessoa';

@Component({
	selector: 'login',
	templateUrl: './login.component.html'
})
export class LoginComponent {
	pessoas: Pessoa[];

	constructor(private btService: BTechServices, private appService: AppService, private router: Router) {
		btService.getPessoas().subscribe(data => this.pessoas = data.json());
	}

	LoginUser(inUser: Pessoa) {
		this.appService.setUserLogged(inUser);
		this.router.navigate(['/home'])
	}
}