import { Component, OnInit } from '@angular/core';
import { Order } from '../../models/order';
import { CartService } from '../../services/cart/cart.service';
import { OrderService } from '../../services/order/order.service';
import { take } from 'rxjs/operators';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrderedProduct } from '../../models/ordered-product';
import { PaymentType } from '../../models/payment-type';
import { DeliveryType } from '../../models/delivery-type';
import { DeliveryTypeService } from '../../services/delivery-type/delivery-type.service';
import { PaymentTypeService } from '../../services/payment-type/payment-type.service';

const nameRegex = '^([0-9]|[A-Za-zÀ-ÿ])([0-9]|[A-Za-zÀ-ÿ]|[ \-&,.])+';

@Component({
    selector: 'app-order-form',
    templateUrl: './order-form.component.html',
    styleUrls: ['./order-form.component.scss']
})
export class OrderFormComponent implements OnInit {

    products: OrderedProduct[];
    price: number;
    fullPrice: number;

    paymentTypes: PaymentType[];
    deliveryTypes: DeliveryType[];

    public form: FormGroup;
    public customerGroup: FormGroup;
    public addressGroup: FormGroup;
    formSubmitted: boolean = false;

    constructor(private cartService: CartService,
        private orderService: OrderService,
        private deliveryTypeService: DeliveryTypeService,
        private paymentTypeService: PaymentTypeService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.deliveryTypeService.getDeliveryTypes().subscribe(
            data => this.deliveryTypes = data);

        this.paymentTypeService.getPaymentTypes().subscribe(
            data => this.paymentTypes = data);

        this.cartService.cartState.pipe(take(1)).subscribe(
            data => {
                this.products = data;
                this.price = this.orderService.getFullPrice(data);
            });

        this.addressGroup = this.formBuilder.group({
            street: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern(nameRegex)]],
            apartmentNumber: ['', [Validators.maxLength(8)]],
            houseNumber: ['', [Validators.required, Validators.maxLength(8)]],
            postalCode: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(10), Validators.pattern('[0-9\-]+')]],
            town: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern(nameRegex)]]
        });

        this.customerGroup = this.formBuilder.group({
            firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(30), Validators.pattern(nameRegex)]],
            lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(30), Validators.pattern(nameRegex)]],
            address: this.addressGroup,
            phoneNumber: ['', [Validators.minLength(9), Validators.maxLength(11), Validators.pattern('[0-9]+')]],
            email: ['', [Validators.email]]
        });

        this.form = this.formBuilder.group({
            customer: this.customerGroup,
            deliveryType: ['', Validators.required],
            paymentType: ['', Validators.required]
        });

        this.calculateFullPrice();
    }

    save(model: any) {
        this.formSubmitted = true;
        const tmpModel: Order = { ...model.value };

        tmpModel.products = this.products;

        //this.burgerService
        //    .postBurger(tmpModel)
        //    .subscribe(
        //        data => this.router.navigateByUrl(`/configure/${data.code}`),
        //        _ => {
        //            this.formSubmitted = false
        //        });
    }

    calculateFullPrice() {
        const deliveryPrice: number = +this.form.get("deliveryType").value.price || 0;
        const paymentPrice: number = +this.form.get("paymentType").value.price || 0;
        this.fullPrice = this.price + deliveryPrice + paymentPrice;
    }
}
