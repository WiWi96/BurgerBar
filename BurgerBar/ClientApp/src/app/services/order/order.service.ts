import { Injectable } from '@angular/core';
import { OrderedProduct } from '../../models/ordered-product';

@Injectable({
    providedIn: 'root'
})
export class OrderService {

    constructor() { }

    getPrice(op: OrderedProduct): number {
        if (op && op.product)
            return op.quantity * op.product.price;
    }

    getFullPrice(ops: OrderedProduct[]): number {
        let price = 0;
        ops.forEach(op => price += this.getPrice(op));
        return price;
    }
}
