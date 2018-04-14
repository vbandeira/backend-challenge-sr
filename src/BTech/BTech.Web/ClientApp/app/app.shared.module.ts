import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { FichaListaComponent } from './components/fichaList/fichaList.component';
import { FichaComponent } from './components/ficha/ficha.component';
import { PessoaComponent } from './components/pessoas/pessoa.component';
import { PessoaListComponent } from './components/pessoaList/pessoaList.component';
import { ExercicioComponent } from './components/exercicio/exercicio.component';
import { SerieComponent } from './components/serie/serie.component';

import { BTechServices } from './services/BTechServices';
import { AppService } from './services/AppService';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
		HomeComponent,
        LoginComponent,
        FichaComponent,
		PessoaComponent,
		PessoaListComponent,
		FichaListaComponent,
		ExercicioComponent,
		SerieComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
			{ path: '', redirectTo: 'login', pathMatch: 'full' },
			{ path: 'login', component: LoginComponent },
            { path: 'home', component: HomeComponent },
            { path: 'ficha', component: FichaListaComponent },
            { path: 'pessoas', component: PessoaListComponent },
            { path: '**', redirectTo: 'home' }
        ])
	],
	providers: [
		BTechServices,
		AppService
	]
})
export class AppModuleShared {
}
