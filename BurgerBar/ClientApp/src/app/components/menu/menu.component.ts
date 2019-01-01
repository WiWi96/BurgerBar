import { Component, OnInit } from '@angular/core';
import { OtherProduct } from '../../models/other-product';
import { ProductService } from '../../services/product/product.service';
import { ProductType } from '../../models/product-type';
import { BurgerService } from '../../services/burger/burger.service';
import { Burger } from '../../models/burger';
import { Product } from '../../models/product';
import { CartService } from '../../services/cart/cart.service';
import { faWrench } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
    products: OtherProduct[];
    types: ProductType[];
    burgers: Burger[];

    faWrench = faWrench;

    constructor(private burgerService: BurgerService,
        private productService: ProductService,
        private cartService: CartService) { }

    ngOnInit() {
        this.getBurgers();
        this.getProductTypes();
        this.getProducts();
    }
    getBurgers(): any {
        this.burgerService.getMenuBurgers().subscribe(data => this.burgers = data);
    }

    getProducts() {
        this.productService.getMenuProducts().subscribe(data => this.products = data);
    }

    getProductTypes() {
        this.productService.getProductTypes().subscribe(data => this.types = data);
    }

    getProductsOfType(type: ProductType): OtherProduct[] {
        if (this.products) {
            return this.products.filter(x => (x.type.id === type.id));
        }
        return null;
    }

    orderProduct(product: Product) {
        this.cartService.addProduct(product);
    }
}
