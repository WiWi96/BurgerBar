import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../services/order/order.service';
import { Order } from '../../../models/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
    orders: Order[];

    constructor(private service: OrderService) { }

    ngOnInit() {
        this.getOrders();
    }

    getOrders() {
        this.service.getAllOrders().subscribe(data => this.orders = data);
    }
}
