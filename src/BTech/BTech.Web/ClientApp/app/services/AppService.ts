import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';

import { Pessoa } from '../models/Pessoa';



@Injectable()
export class AppService {
	private pessoa = new BehaviorSubject<Pessoa>(new Pessoa());

	getUserLogged(): Observable<Pessoa> {
		return this.pessoa.asObservable();
	}

	setUserLogged(inPessoa: Pessoa) {
		this.pessoa.next(inPessoa);
		sessionStorage.setItem('usuarioLogado.login', inPessoa.login);
	}
}