import { Component, OnInit, Input } from '@angular/core';
import { OrderedProductDetails } from '../../../models/ordered-product-details';
import { OrderService } from '../../../services/order/order.service';

@Component({
    selector: 'app-order-products',
    templateUrl: './order-products.component.html',
    styleUrls: ['./order-products.component.scss']
})
export class OrderProductsComponent implements OnInit {

    @Input() products: OrderedProductDetails[];
    price: number;

    constructor(private orderService: OrderService) { }

    ngOnInit() {
        this.price = this.orderService.getFullPrice(this.products);
    }

}
