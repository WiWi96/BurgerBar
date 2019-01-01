import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderToAdd } from '../../models/order-to-add';
import { Observable } from 'rxjs';
import { OrderDetails } from '../../models/order-details';
import { environment } from '../../../environments/environment';
import { OrderedProductDetails } from '../../models/ordered-product-details';
import { Order } from '../../models/order';

@Injectable({
    providedIn: 'root'
})
export class OrderService {
    private apiPath = environment.api + '/Orders';

    constructor(private client: HttpClient) { }

    getPrice(op: OrderedProductDetails): number {
        if (op && op.product)
            return op.quantity * op.product.price;
    }

    getFullPrice(ops: OrderedProductDetails[]): number {
        let price = 0;
        ops.forEach(op => price += this.getPrice(op));
        return price;
    }

    public postOrder(order: OrderToAdd): Observable<OrderDetails> {
        return this.client.post<OrderDetails>(this.apiPath, order);
    }

    public getAllOrders(): Observable<Order[]> {
        return this.client.get<Order[]>(this.apiPath);
    }

    public getOrderDetails(id: number): Observable<OrderDetails> {
        return this.client.get<OrderDetails>(`${this.apiPath}/${id}`);
    }
}
