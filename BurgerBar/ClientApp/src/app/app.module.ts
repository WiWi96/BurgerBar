import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TabsModule } from 'ngx-bootstrap';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BurgerService } from './services/burger/burger.service';
import { ConfiguratorComponent } from './components/configurator/configurator.component';
import { SettingsComponent } from './components/settings/settings.component';
import { IngredientsComponent } from './components/ingredients/ingredients.component';
import { IngredientService } from './services/ingredient/ingredient.service';

@NgModule({
	declarations: [
		AppComponent,
		NavMenuComponent,
		HomeComponent,
		ConfiguratorComponent,
		SettingsComponent,
		IngredientsComponent
	],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		TabsModule.forRoot(),
		FontAwesomeModule,
		RouterModule.forRoot([
			{ path: '', component: HomeComponent, pathMatch: 'full' },
			{ path: 'settings', component: SettingsComponent, pathMatch: 'full' }
		])
	],
	providers: [BurgerService, IngredientService],
	bootstrap: [AppComponent]
})
export class AppModule { }
