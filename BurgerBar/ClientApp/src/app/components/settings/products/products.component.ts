import { Component, OnInit } from '@angular/core';
import { ProductType } from '../../../models/product-type';
import { faWrench, faTimesCircle } from '@fortawesome/free-solid-svg-icons';
import { faCheckCircle } from '@fortawesome/free-regular-svg-icons';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { ProductService } from '../../../services/product/product.service';
import { ProductModalComponent } from '../../modals/product-modal/product-modal.component';
import { OtherProduct } from '../../../models/other-product';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
    products: OtherProduct[];
    types: ProductType[];
    faWrench = faWrench;
    faCheckCircle = faCheckCircle;
    faTimesCircle = faTimesCircle;

    bsModalRef: BsModalRef;

    constructor(private service: ProductService,
        private modalService: BsModalService) { }

    ngOnInit() {
        this.getProductTypes();
        this.getProducts();
    }

    getProducts() {
        this.service.getProducts().subscribe(data => this.products = data);
    }

    getProductTypes() {
        this.service.getProductTypes().subscribe(data => this.types = data);
    }

    addProduct() {
        this.openProductModal();
    }

    editProduct(id: number) {
        this.openProductModal(id);
    }

    getProductsOfType(type: ProductType): OtherProduct[] {
        if (this.products) {
            return this.products.filter(x => (x.type.id === type.id));
        }
        return null;
    }

    openProductModal(id?: any) {
        const initialState = {
            id
        };
        this.bsModalRef = this.modalService.show(ProductModalComponent, { initialState });
        this.bsModalRef.content.onClose.subscribe(result => {
            if (typeof (id) === 'number') {
                const index = this.products.findIndex((elem) => elem.id === result.id);
                this.products[index] = result;
            } else {
                this.products.push(result);
            }
        });
    }
}
