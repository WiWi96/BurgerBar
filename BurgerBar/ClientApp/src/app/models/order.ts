import { Customer } from './customer';
import { OrderedProduct } from './ordered-product';

export class Order {
    customer: Customer;
    products: Array<OrderedProduct> = [];
    deliveryTypeId: number;
    paymentTypeId: number;
}
