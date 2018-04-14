import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Pessoa } from '../models/Pessoa';


@Injectable()
export class BTechServices {
	serviceBase: string = 'http://localhost:52673/api/';

	constructor(private http: Http) { }

	getPessoas() {
		return this.http.get(this.serviceBase + 'Pessoa');
	}

	getPessoa(idPessoa: number) {
		return this.http.get(this.serviceBase + 'Pessoa/' + idPessoa);
	}

	getFichas() {
		return this.http.get(this.serviceBase + 'Ficha');
	}

	getFicha(idFicha: number) {
		return this.http.get(this.serviceBase + 'Ficha/' + idFicha);
	}

	getSerie(idSerie: number) {
		return this.http.get(this.serviceBase + 'Serie/' + idSerie);
	}
}