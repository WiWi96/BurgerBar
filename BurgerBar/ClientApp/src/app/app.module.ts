import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TabsModule, BsModalService, ModalModule, BsDropdownModule } from 'ngx-bootstrap';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BurgerService } from './services/burger/burger.service';
import { ConfiguratorComponent } from './components/configurator/configurator.component';
import { SettingsComponent } from './components/settings/settings.component';
import { IngredientsComponent } from './components/settings/ingredients/ingredients.component';
import { IngredientService } from './services/ingredient/ingredient.service';
import { ProductsComponent } from './components/settings/products/products.component';
import { BurgersComponent } from './components/settings/burgers/burgers.component';
import { BunsComponent } from './components/settings/buns/buns.component';
import { MenuComponent } from './components/menu/menu.component';
import { IngredientModalComponent } from './components/modals/ingredient-modal/ingredient-modal.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ConfiguratorComponent,
        SettingsComponent,
        IngredientsComponent,
        ProductsComponent,
        BurgersComponent,
        BunsComponent,
        MenuComponent,
        IngredientModalComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        TabsModule.forRoot(),
        ModalModule.forRoot(),
        BsDropdownModule.forRoot(),
        FontAwesomeModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'settings', component: SettingsComponent, pathMatch: 'full' }
        ])
    ],
    providers: [BurgerService, IngredientService],
    bootstrap: [AppComponent],
    entryComponents: [IngredientModalComponent]
})
export class AppModule { }
