import { Component, Input } from '@angular/core';
import { Pessoa } from '../../models/Pessoa';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
	@Input() usuario: Pessoa;
}
