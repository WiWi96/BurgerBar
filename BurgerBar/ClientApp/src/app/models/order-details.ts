import { Customer } from './customer';
import { OrderedProductDetails } from './ordered-product-details';
import { DeliveryType } from './delivery-type';
import { PaymentType } from './payment-type';

export class OrderDetails {
  id?: number;
  customer: Customer;
  products: Array<OrderedProductDetails> = [];
  price: number;
  deliveryType: DeliveryType;
  paymentType: PaymentType;
}
