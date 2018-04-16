﻿import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Pessoa } from '../models/Pessoa';
import { AppService } from './AppService';
import { Exercicio } from '../models/Exercicio';


@Injectable()
export class BTechServices {
	serviceBase: string = 'http://localhost:52673/api/';
	options: RequestOptions;

	constructor(private http: Http, private appService: AppService) { }

	private getHeaders() {
		if (this.appService.jwt == undefined || this.appService.jwt == '')
			return;
		let btHeaders: Headers = new Headers();
		btHeaders.append('Authorization', 'Bearer ' + this.appService.jwt);
		return new RequestOptions({ headers: btHeaders });
	};

	getPessoas() {
		return this.http.get(this.serviceBase + 'Pessoa', this.getHeaders());
	}

	getPessoa(idPessoa: number) {
		return this.http.get(this.serviceBase + 'Pessoa/' + idPessoa, this.getHeaders());
	}

	getClientes() {
		return this.http.get(this.serviceBase + 'Cliente/', this.getHeaders());
	}

	getFichas() {
		return this.http.get(this.serviceBase + 'Ficha', this.getHeaders());
	}

	getFicha(idFicha: number) {
		return this.http.get(this.serviceBase + 'Ficha/' + idFicha, this.getHeaders());
	}

	getFichaCliente(idCliente: number) {
		return this.http.get(this.serviceBase + 'Ficha/GetFichaCliente/' + idCliente, this.getHeaders());
	}

	getFichasProfessor(idProfessor: number) {
		return this.http.get(this.serviceBase + 'Ficha/GetFichasProfessor/' + idProfessor, this.getHeaders());
	}

	getSerie(idSerie: number) {
		return this.http.get(this.serviceBase + 'Serie/' + idSerie, this.getHeaders());
	}

	setSerieConcluida(idSerie: number) {
		return this.http.get(this.serviceBase + 'Serie/ConcluirSerie/' + idSerie, this.getHeaders());
	}

	setAlterarCarga(idExercicio: number, valorCarga: string) {
		return this.http.post(this.serviceBase + 'Exercicio/AlterarCarga/' + idExercicio, {'novaCarga': valorCarga}, this.getHeaders());
	}

	deleteExercicio(idExercicio: number) {
		return this.http.delete(this.serviceBase + 'Exercicio/' + idExercicio, this.getHeaders());
	}

	inserirExercicio(idSerie: number, novoExercicio: Exercicio) {
		return this.http.post(this.serviceBase + 'Serie/InserirExercicio/' + idSerie, novoExercicio, this.getHeaders());
	}
}