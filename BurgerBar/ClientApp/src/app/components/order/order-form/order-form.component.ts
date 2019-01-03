import { Component, OnInit } from '@angular/core';
import { OrderDetails } from '../../../models/order-details';
import { CartService } from '../../../services/cart/cart.service';
import { OrderService } from '../../../services/order/order.service';
import { take } from 'rxjs/operators';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrderedProductDetails } from '../../../models/ordered-product-details';
import { PaymentType } from '../../../models/payment-type';
import { DeliveryType } from '../../../models/delivery-type';
import { DeliveryTypeService } from '../../../services/delivery-type/delivery-type.service';
import { PaymentTypeService } from '../../../services/payment-type/payment-type.service';
import { OrderToAdd } from '../../../models/order-to-add';
import { OrderedProduct } from '../../../models/ordered-product';
import { Router } from '@angular/router';

const nameRegex = '^([0-9]|[A-Za-z\u00C0-\u017F])([0-9A-Za-z\u00C0-\u017F \-&,.])+';

@Component({
    selector: 'app-order-form',
    templateUrl: './order-form.component.html',
    styleUrls: ['./order-form.component.scss']
})
export class OrderFormComponent implements OnInit {

    products: OrderedProductDetails[];
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
        private formBuilder: FormBuilder,
        private router: Router) { }

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
            street: [undefined, [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern(nameRegex)]],
            apartmentNumber: [undefined, [Validators.maxLength(8)]],
            houseNumber: [undefined, [Validators.required, Validators.maxLength(8)]],
            postalCode: [undefined, [Validators.required, Validators.minLength(4), Validators.maxLength(10), Validators.pattern('[0-9\-]+')]],
            town: [undefined, [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern(nameRegex)]]
        });

        this.customerGroup = this.formBuilder.group({
            firstName: [undefined, [Validators.required, Validators.minLength(2), Validators.maxLength(30), Validators.pattern(nameRegex)]],
            lastName: [undefined, [Validators.required, Validators.minLength(2), Validators.maxLength(30), Validators.pattern(nameRegex)]],
            address: this.addressGroup,
            phoneNumber: [undefined, [Validators.minLength(9), Validators.maxLength(11), Validators.pattern('[0-9]+')]],
            email: [undefined, [Validators.email]]
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

        const order = new OrderToAdd();
        order.customer = model.value.customer;
        order.deliveryTypeId = model.value.deliveryType.id;
        order.paymentTypeId = model.value.paymentType.id;
        order.products = this.products.map(x => new OrderedProduct(x.product.id, x.quantity));

        this.orderService
            .postOrder(order)
            .subscribe(
                data => {
                    this.cartService.clearCart();
                    this.orderService.order = data;
                    this.router.navigate(['/order-summary']);
                },
                err => {
                    this.formSubmitted = false;
                    throw err;
                });
    }

    calculateFullPrice() {
        const deliveryPrice: number = +this.form.get("deliveryType").value.price || 0;
        const paymentPrice: number = +this.form.get("paymentType").value.price || 0;
        this.fullPrice = this.price + deliveryPrice + paymentPrice;
    }

    get firstName() {
        return this.form.get('customer').get('firstName');
    }

    get lastName() {
        return this.form.get('customer').get('lastName');
    }

    get phoneNumber() {
        return this.form.get('customer').get('phoneNumber');
    }

    get email() {
        return this.form.get('customer').get('email');
    }

    get deliveryType() {
        return this.form.get('deliveryType');
    }

    get paymentType() {
        return this.form.get('paymentType');
    }

    get street() {
        return this.form.get('customer').get('address').get('street');
    }

    get apartmentNumber() {
        return this.form.get('customer').get('address').get('apartmentNumber');
    }

    get houseNumber() {
        return this.form.get('customer').get('address').get('houseNumber');
    }

    get postalCode() {
        return this.form.get('customer').get('address').get('postalCode');
    }

    get town() {
        return this.form.get('customer').get('address').get('town');
    }
}
