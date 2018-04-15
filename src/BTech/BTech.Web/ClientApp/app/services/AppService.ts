import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';


import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';


import { Pessoa } from '../models/Pessoa';

@Injectable()
export class AppService {

	serviceBase: string = 'http://localhost:52673/api/';

	usuario: BehaviorSubject<Pessoa> = new BehaviorSubject<Pessoa>(new Pessoa());
	jwt: string;

	constructor(private router: Router, private http: Http) { }

	Login(inPessoa: Pessoa) {
		//TODO: Solicitar JWT
		this.usuario.next(inPessoa);
		this.http.post(this.serviceBase + 'Login', inPessoa).subscribe(data => {
			this.jwt = data.json().accessToken;
		});
	}

	Logout() {
		this.usuario.next(new Pessoa());
		this.jwt = '';
		this.router.navigate(['/'])
	}
}