import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TabsModule, BsModalService, ModalModule, BsDropdownModule, SortableModule } from 'ngx-bootstrap';
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
import { ConfiguratorViewerComponent } from './components/configurator/configurator-viewer/configurator-viewer.component';
import { BunModalComponent } from './components/modals/bun-modal/bun-modal.component';
import { BurgerModalComponent } from './components/modals/burger-modal/burger-modal.component';
import { ConfiguratorEditorComponent } from './components/configurator/configurator-editor/configurator-editor.component';
import { IngredientCardComponent } from './components/configurator/ingredient-card/ingredient-card.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { ValidationService } from './services/validation/validation.service';
import { FileService } from './services/file/file.service';
import { UploadComponent } from './components/settings/upload/upload.component';
import { CartService } from './services/cart/cart.service';
import { CartComponent } from './components/cart/cart.component';
import { ProductCounterComponent } from './components/cart/product-counter/product-counter.component';
import { OrderFormComponent } from './components/order-form/order-form.component';
import { LoginComponent } from './components/login/login.component';
import { AuthService } from './services/auth/auth.service';
import { AuthGuard } from './guards/auth-guard.service';
import { Interceptor } from './app.interceptor';
import { JwtHelper } from 'angular2-jwt';
import { OrdersComponent } from './components/settings/orders/orders.component';
import { MenuService } from './services/menu/menu.service';

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
        OrdersComponent,
        MenuComponent,
        IngredientModalComponent,
        ProductModalComponent,
        ConfiguratorViewerComponent,
        BunModalComponent,
        BurgerModalComponent,
        ConfiguratorEditorComponent,
        IngredientCardComponent,
        UploadComponent,
        CartComponent,
        ProductCounterComponent,
        OrderFormComponent,
        LoginComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        DragDropModule,
        TabsModule.forRoot(),
        ModalModule.forRoot(),
        BsDropdownModule.forRoot(),
        SortableModule.forRoot(),
        FontAwesomeModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'configure', component: ConfiguratorComponent, pathMatch: 'full' },
            { path: 'configure/:code', component: ConfiguratorViewerComponent, pathMatch: 'full' },
            { path: 'edit', component: ConfiguratorEditorComponent, pathMatch: 'full' },
            { path: 'edit/:code', component: ConfiguratorEditorComponent, pathMatch: 'full' },
            { path: 'settings', component: SettingsComponent, pathMatch: 'full', canActivate: [AuthGuard] },
            { path: 'menu', component: MenuComponent, pathMatch: 'full' },
            { path: 'cart', component: CartComponent, pathMatch: 'full' },
            { path: 'order', component: OrderFormComponent, pathMatch: 'full' },
            { path: 'login', component: LoginComponent, pathMatch: 'full' }
        ])
    ],
    providers: [{ provide: LOCALE_ID, useValue: 'pl' }, BurgerService, IngredientService, ProductService, BunService, DeliveryTypeService, OrderService, PaymentTypeService, MenuService, ValidationService, FileService, CartService, AuthService, AuthGuard, JwtHelper, {
        provide: HTTP_INTERCEPTORS,
        useClass: Interceptor,
        multi: true
    }],
    bootstrap: [AppComponent],
    entryComponents: [IngredientModalComponent, ProductModalComponent, BunModalComponent, BurgerModalComponent, IngredientCardComponent, UploadComponent]
})
export class AppModule { }
