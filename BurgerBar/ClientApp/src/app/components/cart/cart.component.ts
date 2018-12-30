import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart/cart.service';
import { OrderedProduct } from '../../models/ordered-product';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { OrderService } from '../../services/order/order.service';

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

    products: OrderedProduct[];
    faTimes = faTimes;

    constructor(private cartService: CartService,
        private orderService: OrderService) { }

    ngOnInit() {
        this.cartService.cartState.subscribe(
            data => this.products = data
        );
    }

    deleteProduct(op: OrderedProduct) {
        this.cartService.removeProduct(op.product.id);
    }

}
