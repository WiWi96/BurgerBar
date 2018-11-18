import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
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
import { ProductModalComponent } from './components/modals/product-modal/product-modal.component';
import { ProductService } from './services/product/product.service';
import { BunService } from './services/bun/bun.service';
import { DeliveryTypeService } from './services/delivery-type/delivery-type.service';
import { OrderService } from './services/order/order.service';
import { PaymentTypeService } from './services/payment-type/payment-type.service';
import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';

registerLocaleData(localePl, 'pl');

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
        IngredientModalComponent,
        ProductModalComponent
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
            { path: 'configure', component: ConfiguratorComponent, pathMatch: 'full' },
            { path: 'settings', component: SettingsComponent, pathMatch: 'full' }
        ])
    ],
    providers: [{ provide: LOCALE_ID, useValue: 'pl' }, BurgerService, IngredientService, ProductService, BunService, DeliveryTypeService, OrderService, PaymentTypeService],
    bootstrap: [AppComponent],
    entryComponents: [IngredientModalComponent, ProductModalComponent]
})
export class AppModule { }
