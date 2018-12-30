import { Product } from './product';

export class OrderedProduct {
    id?: number;
    product: Product;
    quantity: number;

    constructor(product: Product);
    constructor(product: Product, quantity: number);
    constructor(product: Product, quantity?: number) {
        this.product = product;
        this.quantity = quantity || 1;
    }
}
