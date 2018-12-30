import { Injectable } from '@angular/core';
import { Product } from '../../models/product';
import { OrderedProduct } from '../../models/ordered-product';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
    private orderedProducts: OrderedProduct[] = [];

    private subject = new BehaviorSubject<OrderedProduct[]>([]);
    private countSubject = new BehaviorSubject<number>(0);

    cartState = this.subject.asObservable();
    cartCount = this.countSubject.asObservable();

    constructor() {
        const cart = localStorage.getItem('cart');
        if (cart) {
            this.orderedProducts = JSON.parse(cart);
        }
        this.subject.next(this.orderedProducts);
        this.countSubject.next(this.getProductsCount());
    }

    addProduct(product: Product) {
        const existingProductIndex = this.orderedProducts.findIndex(x => x.product.id === product.id);
        if (existingProductIndex > -1) {
            this.orderedProducts[existingProductIndex].quantity++;
        }
        else {
            this.orderedProducts.push(new OrderedProduct(product));
        }
        this.saveCart();
    }

    removeProduct(id: number) {
        this.orderedProducts = this.orderedProducts.filter(item => item.product.id !== id);
        this.saveCart();
    }

    changeProductQuantity(product: Product, quantity: number) {
        const existingProductIndex = this.orderedProducts.findIndex(x => x.product.id === product.id);
        if (existingProductIndex > -1) {
            if (quantity <= 0) {
                this.removeProduct(product.id);
                return;
            }
            else {
                this.orderedProducts[existingProductIndex].quantity = quantity;
            }
        }
        this.saveCart();
    }

    getProductsCount(): number {
        return this.orderedProducts.length;
    }

    clearCart() {
        this.orderedProducts = [];
        this.saveCart();
    }

    saveCart() {
        localStorage.setItem('cart', JSON.stringify(this.orderedProducts));
        this.subject.next(this.orderedProducts);
        this.countSubject.next(this.getProductsCount());
    }
}
