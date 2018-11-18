import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product/product.service';
import { BsModalRef } from 'ngx-bootstrap';
import { Product } from '../../../models/product';
import { ProductType } from '../../../models/product-type';

@Component({
  selector: 'app-product-modal',
  templateUrl: './product-modal.component.html',
  styleUrls: ['./product-modal.component.scss']
})
export class ProductModalComponent implements OnInit {

    productTypes: ProductType[];
    editedItem: Product;
    product: Product;
    items: Array<Product> = [];

    constructor(public bsModalRef: BsModalRef,
        private productsService: ProductService) { }

    ngOnInit() {
        this.productsService.getProductTypes().subscribe(
            data => this.productTypes = data);
        this.product = { ...this.editedItem };
    }

    saveProduct() {
        if (this.editedItem) {
            this.productsService.putProduct(this.editedItem.id, this.product).subscribe(data => {
                var index = this.items.findIndex(el => this.compareTypes(el, data));
                if (index > -1)
                    this.items[index] = data;
            });
        }
        else {
            this.productsService.postProduct(this.product).subscribe(data => this.items.push(data));
        }
        this.bsModalRef.hide();
    }

    compareTypes = (a, b) => a && b && a.id === b.id;

}
