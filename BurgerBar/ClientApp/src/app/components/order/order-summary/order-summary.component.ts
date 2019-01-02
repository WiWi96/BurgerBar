import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderService } from '../../../services/order/order.service';
import { OrderDetails } from '../../../models/order-details';

@Component({
    selector: 'app-order-summary',
    templateUrl: './order-summary.component.html',
    styleUrls: ['./order-summary.component.scss']
})
export class OrderSummaryComponent implements OnInit {
    id: number;
    order: OrderDetails;

    constructor(private activatedRoute: ActivatedRoute,
        private router: Router,
        private orderService: OrderService) { }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params =>
            this.id = +params.id,
            _ => this.router.navigate(['/']));

        this.orderService.getOrderDetails(this.id).subscribe(data =>
            this.order = data,
            _ => this.router.navigate(['/']));
    }

}
