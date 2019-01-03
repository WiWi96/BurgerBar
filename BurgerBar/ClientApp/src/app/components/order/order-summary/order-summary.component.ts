import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderService } from '../../../services/order/order.service';
import { OrderDetails } from '../../../models/order-details';

@Component({
    selector: 'app-order-summary',
    templateUrl: './order-summary.component.html',
    styleUrls: ['./order-summary.component.scss']
})
export class OrderSummaryComponent implements OnInit, OnDestroy {
    id: number;
    order: OrderDetails;
    successMessage = false;

    constructor(private activatedRoute: ActivatedRoute,
        private router: Router,
        private orderService: OrderService) { }

    ngOnInit() {
        if (this.orderService.order) {
            this.order = this.orderService.order;
            this.successMessage = true;
        } else {
            this.activatedRoute.params.subscribe(params =>
                this.id = +params.id,
                _ => this.router.navigate(['/']));

            if (this.id) {
                this.orderService.getOrderDetails(this.id).subscribe(data =>
                    this.order = data,
                    err => {
                        this.router.navigate(['/']);
                        throw err;
                    });
            }
            else {
                this.router.navigate(['/']);
            }
        }
    }

    ngOnDestroy() {
        this.orderService.order = null;
    }

}
