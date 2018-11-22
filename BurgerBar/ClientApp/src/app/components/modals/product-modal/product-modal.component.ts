import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product/product.service';
import { BsModalRef } from 'ngx-bootstrap';
import { ProductDetails } from '../../../models/product-details';
import { ProductType } from '../../../models/product-type';
import { Subject } from 'rxjs';

@Component({
    selector: 'app-product-modal',
    templateUrl: './product-modal.component.html',
    styleUrls: ['./product-modal.component.scss']
})
export class ProductModalComponent implements OnInit {
    public onClose: Subject<ProductDetails>;

    id: any;
    productTypes: ProductType[];
    product: ProductDetails = new ProductDetails();

    constructor(public bsModalRef: BsModalRef,
        private productsService: ProductService) { }

    ngOnInit() {
        this.onClose = new Subject();
        this.productsService.getProductTypes().subscribe(
            data => this.productTypes = data);
        if (typeof (this.id) === 'number') {
            this.productsService.getProductDetails(this.id).subscribe(data => this.product = data);
        }
    }

    saveProduct() {
        if (typeof (this.id) === 'number') {
            this.productsService.putProduct(this.id, this.product).subscribe(data => this.onSuccess(data));
        } else {
            this.productsService.postProduct(this.product).subscribe(data => this.onSuccess(data));
        }
    }

    onSuccess(data) {
        this.onClose.next(data);
        this.bsModalRef.hide();
    }

    compareTypes = (a, b) => a && b && a.id === b.id;
}
