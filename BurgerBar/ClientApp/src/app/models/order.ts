import { Customer } from "./customer";
import { OrderedProduct } from "./ordered-product";
import { DeliveryType } from "./delivery-type";
import { PaymentType } from "./payment-type";

export class Order {
  id?: number;
  customer: Customer;
  products: Array<OrderedProduct> = [];
  price: number;
  deliveryType: DeliveryType;
  paymentType: PaymentType;
}
