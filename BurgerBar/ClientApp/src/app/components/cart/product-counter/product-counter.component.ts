import { Component, OnInit, Input } from '@angular/core';
import { faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { OrderedProduct } from '../../../models/ordered-product';
import { CartService } from '../../../services/cart/cart.service';

@Component({
    selector: 'app-product-counter',
    templateUrl: './product-counter.component.html',
    styleUrls: ['./product-counter.component.scss']
})
export class ProductCounterComponent implements OnInit {
    @Input() product: OrderedProduct;

    faMinus = faMinus;
    faPlus = faPlus;

    constructor(private cartService: CartService) { }

    ngOnInit() {
    }

    incrementProduct() {
        this.product.quantity++;
        this.quantityChanged();
    }

    decrementProduct() {
        this.product.quantity--;
        this.quantityChanged();
    }

    quantityChanged() {
        this.cartService.changeProductQuantity(this.product.product, this.product.quantity);
    }
}
