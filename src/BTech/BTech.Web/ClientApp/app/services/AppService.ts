import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';


import { Pessoa } from '../models/Pessoa';

@Injectable()
export class AppService {
	
	usuario = new BehaviorSubject<Pessoa>(new Pessoa());

	constructor(private router: Router) { }

	Login(inPessoa: Pessoa) {
		this.usuario.next(inPessoa);
	}

	Logout() {
		this.usuario.next(new Pessoa());
		this.router.navigate(['/'])
	}
}