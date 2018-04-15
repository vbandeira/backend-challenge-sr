import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Pessoa } from '../../models/Pessoa';
import { AppService } from '../../services/AppService';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
	
	//@Input() usuario: Pessoa;
	//usuario: Observable<Pessoa>; // = new Pessoa();
	//dummy: any;

	constructor(private appService: AppService) {
		
	}

	ngOnInit(): void {
		
	}
}
